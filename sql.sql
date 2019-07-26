/*
SQLyog Community v13.0.1 (64 bit)
MySQL - 10.1.36-MariaDB : Database - mydata
*********************************************************************
Testing.
Testing 2

Test more
Test again
Once more Testing
Okay more Test
*/



/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`mydata` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `mydata`;

/*Table structure for table `vehicle_info` */

DROP TABLE IF EXISTS `vehicle_info`;

CREATE TABLE `vehicle_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `record_id` int(11) NOT NULL COMMENT 'Record ID',
  `time` varchar(200) NOT NULL COMMENT 'Time',
  `type` varchar(250) NOT NULL COMMENT 'Type',
  `groupid` int(11) NOT NULL COMMENT 'Group ID',
  `index` int(11) NOT NULL COMMENT 'Index',
  `count` int(11) NOT NULL COMMENT 'Count',
  `platenumber` varchar(150) NOT NULL COMMENT 'Place Number',
  `platetype` varchar(150) NOT NULL COMMENT 'Place Type',
  `platecolor` varchar(150) NOT NULL COMMENT 'Place Color',
  `vehicletype` varchar(150) NOT NULL COMMENT 'Vehicle Type',
  `vehiclecolor` varchar(150) NOT NULL COMMENT 'Vehicle Color',
  `vehiclesize` varchar(150) NOT NULL COMMENT 'Vehicle Size',
  `lanenumber` varchar(150) NOT NULL COMMENT 'Lane Number',
  `address` varchar(350) NOT NULL COMMENT 'Address',
  `filelenth` varchar(300) NOT NULL COMMENT 'File Lenth',
  `offset` varchar(250) NOT NULL COMMENT 'Offset',
  `buffer` varchar(250) NOT NULL COMMENT 'Buffer',
  `date_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Date Time',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `vehicle_info` */

insert  into `vehicle_info`(`id`,`record_id`,`time`,`type`,`groupid`,`index`,`count`,`platenumber`,`platetype`,`platecolor`,`vehicletype`,`vehiclecolor`,`vehiclesize`,`lanenumber`,`address`,`filelenth`,`offset`,`buffer`,`date_time`) values 
(1,125,'10/3/2018 1:22:07 AM','Event Type',125,125,125,'ABC 123','Plate Type','White','Vehicle Type','Silver','Vehicle Size','2','Address','125','125','System.Byte[]','2018-10-03 01:30:11'),
(2,356,'10/3/2018 1:30:54 AM','Event Type',356,356,356,'ABC 123','Plate Type','White','Vehicle Type','Silver','Vehicle Size','2','Address','356','356','System.Byte[]','2018-10-03 01:31:04');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
