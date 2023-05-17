use master
GO

--Validamos si existe la base de datos
IF EXISTS(select * from sys.databases where name = 'parqueadero')
BEGIN 
    DROP DATABASE parqueadero
END 
GO
--creacion de db
CREATE DATABASE [parqueadero]
GO 
USE [parqueadero]
GO

CREATE SCHEMA [parqueadero];
GO

create table tipo_identificacion(
	tipide_id int identity not null,
	tipide_codigo varchar(3) not null,
	tipide_descrip varchar(100) not null,
	primary key(tipide_id),
	constraint Unique_tipide_codigo
	unique (tipide_codigo asc)
);
GO

create table ciudad(
	ciu_id int identity not null,
	ciu_codigo varchar(8) not null,
	ciu_nombre varchar(100) not null,
	primary key (ciu_id),
	constraint Unique_ciu_codigo
	unique (ciu_codigo)
);
GO

create table tipo_vehiculo(
	tipveh_id int identity not null,
	tipveh_codigo varchar(45) not null,
	tipveh_descrip varchar(60) not null,
	tipveh_tarifa decimal(18,2) not null,
	primary key(tipveh_id),
	constraint Unique_tipveh_codigo
	unique (tipveh_codigo)
);
GO

create table marca(
	mar_id int identity not null,
	mar_codigo varchar(45) not null,
	mar_descrip varchar(100) null default(''),
	primary key (mar_id),
	constraint Unique_mar_codigo
	unique (mar_codigo)
);
GO

create table sucursal(
	suc_id int identity not null,
	tipide_id int not null,
	suc_documento varchar(30) not null,
	ciu_id int not null,
	suc_dir varchar(250) null default('N/A'),
	suc_razon varchar(100) not null,
	suc_maneja_dcto bit not null,
	suc_dcto decimal(18,2) not null,
	primary key (suc_id),
	constraint fk_tipo_identificacion_suc
	foreign key (tipide_id) references tipo_identificacion(tipide_id),
	constraint Unique_tipide_id_suc_documento
	unique (tipide_id,suc_documento asc),
	constraint fk_ciudad_suc
	foreign key (ciu_id) references ciudad(ciu_id)
);
GO

create table distribucion(
	dis_id int identity not null,
	suc_id int not null,
	dis_sigla varchar(4) not null,
	dis_serie int not null,
	dis_habilitado bit not null,
	primary key(dis_id),
	constraint Unique_suc_id_dis_sigla_dis_serie
	unique (suc_id,dis_sigla,dis_serie asc),
	constraint Fk_sucursal_dis
	foreign key (suc_id) references sucursal(suc_id)
);
GO

create table vehiculo(
	veh_id int identity not null,
	tipveh_id int not null,
	mar_id int not null,
	veh_placa varchar(15) not null,
	veh_fec_registro datetime not null,
	primary key (veh_id),
	constraint Fk_tipo_vehiculo_veh
	foreign key (tipveh_id) references tipo_vehiculo(tipveh_id),
	constraint Unique_veh_placa
	unique(veh_placa)
);
GO

create table mov_paqueadero(
	parque_id int identity not null,
	veh_id int not null,
	dis_id int not null,
	parque_hora_in datetime not null,
	parque_hora_out datetime null,
	parque_tiempo_min decimal(18,2) null default(0),
	parque_costo decimal(18,2) null default(0),
	par_fac_dcto varchar(100),
	primary key(parque_id),
	constraint Fk_vehiculo_parque
	foreign key(veh_id) references vehiculo(veh_id),
	constraint Fk_distribucion_parque
	foreign key (dis_id) references distribucion(dis_id)
);
GO

--datos de inicializacion
insert into tipo_identificacion(tipide_codigo,tipide_descrip)
values('13','Cedula de ciudadania'),
('31','Nit');
GO

insert into ciudad(ciu_codigo,ciu_nombre)
values('17001','Manizales');
GO

insert into tipo_vehiculo(tipveh_codigo,tipveh_descrip,tipveh_tarifa)
values('carro','vehiculo de 4 llantas',110),
('motocicleta','vehiculo de 2 llantas',50),
('bicicleta','vehiculo no motor',10);
GO

insert into marca(mar_codigo)
values('hyndai'),('renault'),('chevrolet'),('generico');
GO

/****** Object:  StoredProcedure [dbo].[Sp_liquidacion]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Roland Duque>
-- Create date: <16/05/2023>
-- Description:	<Procedimiento para ingreso y salida de vehiculos por sucursal>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_liquidacion] 
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
	set @idsalida=@@IDENTITY
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
	select a.parque_id ParqueId,
		a.parque_hora_in HoraEntrada,
		convert(datetime,isnull(a.parque_hora_out,'1900-01-01')) HoraSalida,
		a.parque_tiempo_min TiempoParqueo,
		isnull(a.par_fac_dcto,'N/A') DctoDescuento,
		a.parque_costo ValorPagado,
		b.veh_placa Placa,
		c.tipveh_codigo TipoVehiculo,
		c.tipveh_tarifa Tarifa,
		d.dis_id IdParqueo,
		d.dis_sigla+'-'+CONVERT(varchar,d.dis_serie) NumeroParqueo
		from mov_paqueadero as a
		inner join vehiculo as b on b.veh_id=a.veh_id
		inner join tipo_vehiculo as c on c.tipveh_id=b.tipveh_id
		inner join distribucion as d on d.dis_id=a.dis_id
		where a.parque_id=@idsalida
		return
END
GO

