-- create database warehousemanagement;

CREATE TABLE Trucks (
    id int PRIMARY KEY AUTO_INCREMENT,
    warehouse_id int DEFAULT null,
    model_year int not null,
    manufacturer char(30) not null,
    model char(20) not null,
    mileage int not null);

CREATE TABLE `Warehouses` (
  `city` char(20) not null,
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` char(20) not null
);

CREATE TABLE `Products` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` char(20) not null,
  `price` float not null,
  `warehouse_id` int DEFAULT null,
  `order_id` int DEFAULT null,
  `weight` int not null,
  `volume` int not null
);

CREATE TABLE `Cities` (
  `name` char(20) PRIMARY KEY,
  `longitude` float not null,
  `latitude` float not null
);

CREATE TABLE `Semitrailers` (
  `warehouse_id` int DEFAULT null,
  `max_volume` int not null,
  `max_axle_load` int not null,
  `id` int PRIMARY KEY AUTO_INCREMENT
);

CREATE TABLE `Orders` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `date` datetime not null,
  `value` float not null,
  `customer_id` int not null,
  `warehouse_id` int not null,
  `truck_id` int not null,
  `semitrailer_id` int not null
);

CREATE TABLE `Customers` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` char(20) not null,
  `city_name` char(20) not null
);

ALTER TABLE `Trucks` ADD FOREIGN KEY (`warehouse_id`) REFERENCES `Warehouses` (`id`);

ALTER TABLE `Warehouses` ADD FOREIGN KEY (`city`) REFERENCES `Cities` (`name`);

ALTER TABLE `Products` ADD FOREIGN KEY (`warehouse_id`) REFERENCES `Warehouses` (`id`);

ALTER TABLE `Products` ADD FOREIGN KEY (`order_id`) REFERENCES `Orders` (`id`);

ALTER TABLE `Semitrailers` ADD FOREIGN KEY (`warehouse_id`) REFERENCES `Warehouses` (`id`);

ALTER TABLE `Orders` ADD FOREIGN KEY (`customer_id`) REFERENCES `Customers` (`id`);

ALTER TABLE `Orders` ADD FOREIGN KEY (`warehouse_id`) REFERENCES `Warehouses` (`id`);

ALTER TABLE `Orders` ADD FOREIGN KEY (`truck_id`) REFERENCES `Trucks` (`id`);

ALTER TABLE `Orders` ADD FOREIGN KEY (`semitrailer_id`) REFERENCES `Semitrailers` (`id`);

ALTER TABLE `Customers` ADD FOREIGN KEY (`city_name`) REFERENCES `Cities` (`name`);
