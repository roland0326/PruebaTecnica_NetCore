
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Roland Duque>
-- Create date: <16/05/2023>
-- Description:	<Procedimiento para ingreso y salida de vehiculos por sucursal>
-- =============================================
CREATE PROCEDURE Sp_liquidacion 
	 @placa varchar(20),
	 @tipo_veh int,
	 @marca int,
	 @sucursal int,
	 @factura varchar(150)
AS
BEGIN
	declare @ValPLaca varchar(20);
declare @Idveh int;
declare @PuestoLibre int;
declare @idparque int;
declare @inout int;
declare @parqueado int;
declare @costo decimal(18,2);
declare @dcto decimal(18,2);
declare @manejadcto bit;
declare @idsalida int;
declare @horaingreso datetime;

set @inout=0; 
select @ValPLaca=veh_placa from vehiculo where veh_placa=@placa
print @ValPLaca
if(@ValPLaca is null)
	begin 
		insert into vehiculo(tipveh_id,mar_id,veh_placa,veh_fec_registro)
		values(@tipo_veh,@marca,@placa,getdate());
		set @Idveh= @@IDENTITY
		set @inout=1
	end
else
	begin 
		select @Idveh= veh_id from vehiculo where veh_placa=@placa;
		set @inout=1
	end
print @Idveh 
	--validamos que no este parqueado
select @parqueado= count(*) from mov_paqueadero where veh_id=@Idveh and parque_hora_out is null
--print @parqueado
if(@parqueado>0)
begin 
	set @inout=0
end
--print @inout
if (@inout=1)
	begin
	select @idparque=min(dis_id)
	from distribucion as a
	where dis_habilitado=1 and dis_id not in (select dis_id from mov_paqueadero where parque_hora_out is null)
	and suc_id=@sucursal;

	insert into mov_paqueadero(veh_id,dis_id,parque_hora_in)
	values(@Idveh,@idparque,getdate());
end
else
	begin
		--averiguamos los costos del vehiculo
		select @idsalida= parque_id , @horaingreso= parque_hora_in from mov_paqueadero where veh_id=@Idveh and parque_hora_out is null
--print @idsalida
--print @horaingreso
		select @manejadcto=suc_maneja_dcto,@dcto=suc_dcto from sucursal where suc_id=@sucursal;
--print @manejadcto
--print @dcto
		select @costo= tipveh_tarifa from tipo_vehiculo where tipveh_id=(select tipveh_id from vehiculo where veh_id=@Idveh)
--print @costo
		if(@manejadcto=1 and @factura<>'')
		begin 
			set @costo=@costo-(@costo*(@dcto/100))
		end
		if(@factura='')
		begin 
			set @factura='N/A'+convert(varchar,@idsalida)
		end

		--select @costo,@factura,@idparque
		update mov_paqueadero
		set parque_hora_out=getdate(),
		parque_costo=@costo,
		parque_tiempo_min=convert(decimal(18,2),DATEDIFF(MINUTE,@horaingreso,getdate())),
		par_fac_dcto=@factura
		where parque_id=@idsalida;

		
	end
END
GO
