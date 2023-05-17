USE [parqueadero]
GO
/****** Object:  Table [dbo].[ciudad]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ciudad](
	[ciu_id] [int] IDENTITY(1,1) NOT NULL,
	[ciu_codigo] [varchar](8) NOT NULL,
	[ciu_nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ciu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_ciu_codigo] UNIQUE NONCLUSTERED 
(
	[ciu_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[distribucion]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distribucion](
	[dis_id] [int] IDENTITY(1,1) NOT NULL,
	[suc_id] [int] NOT NULL,
	[dis_sigla] [varchar](4) NOT NULL,
	[dis_serie] [int] NOT NULL,
	[dis_habilitado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[dis_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_suc_id_dis_sigla_dis_serie] UNIQUE NONCLUSTERED 
(
	[suc_id] ASC,
	[dis_sigla] ASC,
	[dis_serie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[mar_id] [int] IDENTITY(1,1) NOT NULL,
	[mar_codigo] [varchar](45) NOT NULL,
	[mar_descrip] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[mar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_mar_codigo] UNIQUE NONCLUSTERED 
(
	[mar_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mov_paqueadero]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mov_paqueadero](
	[parque_id] [int] IDENTITY(1,1) NOT NULL,
	[veh_id] [int] NOT NULL,
	[dis_id] [int] NOT NULL,
	[parque_hora_in] [datetime] NOT NULL,
	[parque_hora_out] [datetime] NULL,
	[parque_tiempo_min] [decimal](18, 2) NULL,
	[parque_costo] [decimal](18, 2) NULL,
	[par_fac_dcto] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[parque_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_par_fac_dcto] UNIQUE NONCLUSTERED 
(
	[par_fac_dcto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sucursal]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sucursal](
	[suc_id] [int] IDENTITY(1,1) NOT NULL,
	[tipide_id] [int] NOT NULL,
	[suc_documento] [varchar](30) NOT NULL,
	[ciu_id] [int] NOT NULL,
	[suc_dir] [varchar](250) NULL,
	[suc_razon] [varchar](100) NOT NULL,
	[suc_maneja_dcto] [bit] NOT NULL,
	[suc_dcto] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[suc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_tipide_id_suc_documento] UNIQUE NONCLUSTERED 
(
	[tipide_id] ASC,
	[suc_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_identificacion]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_identificacion](
	[tipide_id] [int] IDENTITY(1,1) NOT NULL,
	[tipide_codigo] [varchar](3) NOT NULL,
	[tipide_descrip] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tipide_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_tipide_codigo] UNIQUE NONCLUSTERED 
(
	[tipide_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_vehiculo]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_vehiculo](
	[tipveh_id] [int] IDENTITY(1,1) NOT NULL,
	[tipveh_codigo] [varchar](45) NOT NULL,
	[tipveh_descrip] [varchar](60) NOT NULL,
	[tipveh_tarifa] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tipveh_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_tipveh_codigo] UNIQUE NONCLUSTERED 
(
	[tipveh_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 16/05/2023 5:28:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[veh_id] [int] IDENTITY(1,1) NOT NULL,
	[tipveh_id] [int] NOT NULL,
	[mar_id] [int] NOT NULL,
	[veh_placa] [varchar](15) NOT NULL,
	[veh_fec_registro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[veh_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Unique_veh_placa] UNIQUE NONCLUSTERED 
(
	[veh_placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[marca] ADD  DEFAULT ('') FOR [mar_descrip]
GO
ALTER TABLE [dbo].[mov_paqueadero] ADD  DEFAULT ((0)) FOR [parque_tiempo_min]
GO
ALTER TABLE [dbo].[mov_paqueadero] ADD  DEFAULT ((0)) FOR [parque_costo]
GO
ALTER TABLE [dbo].[sucursal] ADD  DEFAULT ('N/A') FOR [suc_dir]
GO
ALTER TABLE [dbo].[distribucion]  WITH CHECK ADD  CONSTRAINT [Fk_sucursal_dis] FOREIGN KEY([suc_id])
REFERENCES [dbo].[sucursal] ([suc_id])
GO
ALTER TABLE [dbo].[distribucion] CHECK CONSTRAINT [Fk_sucursal_dis]
GO
ALTER TABLE [dbo].[mov_paqueadero]  WITH CHECK ADD  CONSTRAINT [Fk_distribucion_parque] FOREIGN KEY([dis_id])
REFERENCES [dbo].[distribucion] ([dis_id])
GO
ALTER TABLE [dbo].[mov_paqueadero] CHECK CONSTRAINT [Fk_distribucion_parque]
GO
ALTER TABLE [dbo].[mov_paqueadero]  WITH CHECK ADD  CONSTRAINT [Fk_vehiculo_parque] FOREIGN KEY([veh_id])
REFERENCES [dbo].[vehiculo] ([veh_id])
GO
ALTER TABLE [dbo].[mov_paqueadero] CHECK CONSTRAINT [Fk_vehiculo_parque]
GO
ALTER TABLE [dbo].[sucursal]  WITH CHECK ADD  CONSTRAINT [fk_ciudad_suc] FOREIGN KEY([ciu_id])
REFERENCES [dbo].[ciudad] ([ciu_id])
GO
ALTER TABLE [dbo].[sucursal] CHECK CONSTRAINT [fk_ciudad_suc]
GO
ALTER TABLE [dbo].[sucursal]  WITH CHECK ADD  CONSTRAINT [fk_tipo_identificacion_suc] FOREIGN KEY([tipide_id])
REFERENCES [dbo].[tipo_identificacion] ([tipide_id])
GO
ALTER TABLE [dbo].[sucursal] CHECK CONSTRAINT [fk_tipo_identificacion_suc]
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD  CONSTRAINT [Fk_tipo_vehiculo_veh] FOREIGN KEY([tipveh_id])
REFERENCES [dbo].[tipo_vehiculo] ([tipveh_id])
GO
ALTER TABLE [dbo].[vehiculo] CHECK CONSTRAINT [Fk_tipo_vehiculo_veh]
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
