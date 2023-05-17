
--drop database [parqueadero]
--create database [parqueadero]
--use parqueadero

create table tipo_identificacion(
	tipide_id int identity not null,
	tipide_codigo varchar(3) not null,
	tipide_descrip varchar(100) not null,
	primary key(tipide_id),
	constraint Unique_tipide_codigo
	unique (tipide_codigo asc)
);
insert into tipo_identificacion(tipide_codigo,tipide_descrip)
values('13','Cedula de ciudadania'),
('31','Nit');

create table ciudad(
	ciu_id int identity not null,
	ciu_codigo varchar(8) not null,
	ciu_nombre varchar(100) not null,
	primary key (ciu_id),
	constraint Unique_ciu_codigo
	unique (ciu_codigo)
);
insert into ciudad(ciu_codigo,ciu_nombre)
values('17001','Manizales');

create table tipo_vehiculo(
	tipveh_id int identity not null,
	tipveh_codigo varchar(45) not null,
	tipveh_descrip varchar(60) not null,
	tipveh_tarifa decimal(18,2) not null,
	primary key(tipveh_id),
	constraint Unique_tipveh_codigo
	unique (tipveh_codigo)
);
insert into tipo_vehiculo(tipveh_codigo,tipveh_descrip,tipveh_tarifa)
values('carro','vehiculo de 4 llantas',110),
('motocicleta','vehiculo de 2 llantas',50),
('bicicleta','vehiculo no motor',10);

create table marca(
	mar_id int identity not null,
	mar_codigo varchar(45) not null,
	mar_descrip varchar(100) null default(''),
	primary key (mar_id),
	constraint Unique_mar_codigo
	unique (mar_codigo)
);
insert into marca(mar_codigo)
values('hyndai'),('renault'),('chevrolet'),('generico');

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
	foreign key (dis_id) references distribucion(dis_id),
	constraint Unique_par_fac_dcto
	unique (par_fac_dcto)
);

