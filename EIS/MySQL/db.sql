-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: eis
-- ------------------------------------------------------
-- Server version	5.5.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `eis`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `eis` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `eis`;

--
-- Table structure for table `availableyears`
--

DROP TABLE IF EXISTS `availableyears`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `availableyears` (
  `Year` int(11) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  PRIMARY KEY (`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `availableyears`
--

LOCK TABLES `availableyears` WRITE;
/*!40000 ALTER TABLE `availableyears` DISABLE KEYS */;
INSERT INTO `availableyears` VALUES (2551,'2013-03-18 15:17:40'),(2552,'2013-03-18 15:17:33'),(2553,'2013-03-07 07:25:07'),(2554,'2013-03-07 07:13:43'),(2555,'2013-03-07 06:13:36'),(2556,'2013-03-07 04:20:18');
/*!40000 ALTER TABLE `availableyears` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bankloanapproval`
--

DROP TABLE IF EXISTS `bankloanapproval`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bankloanapproval` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `BankTypeId` int(11) NOT NULL,
  `NumberOfPeople` int(11) NOT NULL DEFAULT '0',
  `Amount` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_BankType` (`BankTypeId`),
  CONSTRAINT `FK_BankType` FOREIGN KEY (`BankTypeId`) REFERENCES `banktype` (`BankTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankloanapproval`
--

LOCK TABLES `bankloanapproval` WRITE;
/*!40000 ALTER TABLE `bankloanapproval` DISABLE KEYS */;
INSERT INTO `bankloanapproval` VALUES (16,2556,1,2585,976,'2013-04-03 08:04:22'),(17,2556,2,59,17,'2013-04-03 08:04:22'),(18,2556,3,7080,2635,'2013-04-03 08:04:22'),(19,2556,4,308,138,'2013-04-03 08:04:22'),(20,2556,5,1576,583,'2013-04-03 08:04:22'),(21,2555,1,7424,2296,'2013-04-03 08:05:34'),(22,2555,2,1235,353,'2013-04-03 08:05:34'),(23,2555,3,30052,9527,'2013-04-03 08:05:34'),(24,2555,4,867,337,'2013-04-03 08:05:34'),(25,2555,5,5778,1820,'2013-04-03 08:05:34'),(26,2554,1,15594,4633,'2013-04-03 08:07:39'),(27,2554,2,717,234,'2013-04-03 08:07:39'),(28,2554,3,34034,10058,'2013-04-03 08:07:39'),(29,2554,4,2,0,'2013-04-03 08:07:39'),(30,2554,5,8725,2714,'2013-04-03 08:07:39'),(36,2553,1,0,0,'2013-03-07 00:25:07'),(37,2553,2,0,0,'2013-03-07 00:25:07'),(38,2553,3,0,0,'2013-03-07 00:25:07'),(39,2553,4,0,0,'2013-03-07 00:25:07'),(40,2553,5,0,0,'2013-03-07 00:25:07'),(41,2552,1,0,0,'2013-03-18 08:17:34'),(42,2552,2,0,0,'2013-03-18 08:17:34'),(43,2552,3,0,0,'2013-03-18 08:17:34'),(44,2552,4,0,0,'2013-03-18 08:17:34'),(45,2552,5,0,0,'2013-03-18 08:17:34'),(46,2551,1,0,0,'2013-03-18 08:17:40'),(47,2551,2,0,0,'2013-03-18 08:17:40'),(48,2551,3,0,0,'2013-03-18 08:17:40'),(49,2551,4,0,0,'2013-03-18 08:17:40'),(50,2551,5,0,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `bankloanapproval` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banktype`
--

DROP TABLE IF EXISTS `banktype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `banktype` (
  `BankTypeId` int(11) NOT NULL,
  `BankName` varchar(255) NOT NULL,
  PRIMARY KEY (`BankTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banktype`
--

LOCK TABLES `banktype` WRITE;
/*!40000 ALTER TABLE `banktype` DISABLE KEYS */;
INSERT INTO `banktype` VALUES (1,'ธนาคารกรุงเทพ'),(2,'ธนาคารกสิกร'),(3,'ธนาคารกรุงไทย'),(4,'ธนาคารทหารไทย'),(5,'ธนาคารออมสิน');
/*!40000 ALTER TABLE `banktype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `budgettype`
--

DROP TABLE IF EXISTS `budgettype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `budgettype` (
  `BudgetTypeId` int(11) NOT NULL,
  `TypeName` varchar(45) NOT NULL,
  PRIMARY KEY (`BudgetTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `budgettype`
--

LOCK TABLES `budgettype` WRITE;
/*!40000 ALTER TABLE `budgettype` DISABLE KEYS */;
INSERT INTO `budgettype` VALUES (1,'รายจ่ายประจำ'),(2,'รายจ่ายลงทุน');
/*!40000 ALTER TABLE `budgettype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `budgetusage`
--

DROP TABLE IF EXISTS `budgetusage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `budgetusage` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `BudgetType` int(11) NOT NULL,
  `BudgetAmount` decimal(10,0) NOT NULL DEFAULT '0',
  `Used` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_BudgetType` (`BudgetType`),
  CONSTRAINT `FK_BudgetType` FOREIGN KEY (`BudgetType`) REFERENCES `budgettype` (`BudgetTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `budgetusage`
--

LOCK TABLES `budgetusage` WRITE;
/*!40000 ALTER TABLE `budgetusage` DISABLE KEYS */;
INSERT INTO `budgetusage` VALUES (7,2556,1,1725733,263795,'2013-03-28 23:18:38'),(8,2556,2,344267,23978,'2013-03-28 23:18:38'),(9,2555,1,1600000,800000,'2013-04-07 22:38:47'),(10,2555,2,300000,150000,'2013-04-07 22:38:47'),(11,2554,1,1500000,750000,'2013-04-07 22:40:07'),(12,2554,2,280000,140000,'2013-04-07 22:40:07'),(15,2553,1,1400000,700000,'2013-04-07 23:09:37'),(16,2553,2,250000,125000,'2013-04-07 23:09:37'),(17,2552,1,1200000,600000,'2013-04-07 23:10:19'),(18,2552,2,220000,110000,'2013-04-07 23:10:19'),(19,2551,1,0,0,'2013-03-18 08:17:40'),(20,2551,2,0,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `budgetusage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employeerelatedbudgettype`
--

DROP TABLE IF EXISTS `employeerelatedbudgettype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employeerelatedbudgettype` (
  `EmployeeRelatedBudgetTypeId` int(11) NOT NULL,
  `TypeName` varchar(255) NOT NULL,
  PRIMARY KEY (`EmployeeRelatedBudgetTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeerelatedbudgettype`
--

LOCK TABLES `employeerelatedbudgettype` WRITE;
/*!40000 ALTER TABLE `employeerelatedbudgettype` DISABLE KEYS */;
INSERT INTO `employeerelatedbudgettype` VALUES (1,'เงินเดือน'),(2,'ค่าจ้างประจำ'),(3,'ค่าจ้างชั่วคราว'),(4,'พนักงานราชการ');
/*!40000 ALTER TABLE `employeerelatedbudgettype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employeerelatedbudgetusage`
--

DROP TABLE IF EXISTS `employeerelatedbudgetusage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employeerelatedbudgetusage` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `EmployeeRelatedBudgetTypeId` int(11) NOT NULL,
  `Amount` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_EmployeeRelatedBudgetType` (`EmployeeRelatedBudgetTypeId`),
  CONSTRAINT `FK_EmployeeRelatedBudgetType` FOREIGN KEY (`EmployeeRelatedBudgetTypeId`) REFERENCES `employeerelatedbudgettype` (`EmployeeRelatedBudgetTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeerelatedbudgetusage`
--

LOCK TABLES `employeerelatedbudgetusage` WRITE;
/*!40000 ALTER TABLE `employeerelatedbudgetusage` DISABLE KEYS */;
INSERT INTO `employeerelatedbudgetusage` VALUES (13,2556,1,218173,'2013-03-18 08:38:11'),(14,2556,2,13311,'2013-03-18 08:38:11'),(15,2556,3,716,'2013-03-18 08:38:11'),(16,2556,4,8380,'2013-03-18 08:38:11'),(17,2555,1,489695,'2013-03-18 08:36:25'),(18,2555,2,31732,'2013-03-18 08:36:25'),(19,2555,3,1394,'2013-03-18 08:36:25'),(20,2555,4,18380,'2013-03-18 08:36:25'),(21,2554,1,452172,'2013-03-18 08:35:48'),(22,2554,2,31476,'2013-03-18 08:35:48'),(23,2554,3,988,'2013-03-18 08:35:48'),(24,2554,4,14211,'2013-03-18 08:35:48'),(29,2553,1,418018,'2013-03-18 08:34:33'),(30,2553,2,30129,'2013-03-18 08:34:33'),(31,2553,3,1451,'2013-03-18 08:34:33'),(32,2553,4,11874,'2013-03-18 08:34:33'),(33,2552,1,0,'2013-03-18 08:17:33'),(34,2552,2,0,'2013-03-18 08:17:33'),(35,2552,3,0,'2013-03-18 08:17:33'),(36,2552,4,0,'2013-03-18 08:17:33'),(37,2551,1,0,'2013-03-18 08:17:40'),(38,2551,2,0,'2013-03-18 08:17:40'),(39,2551,3,0,'2013-03-18 08:17:40'),(40,2551,4,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `employeerelatedbudgetusage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employeetype`
--

DROP TABLE IF EXISTS `employeetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employeetype` (
  `EmployeeTypeId` int(11) NOT NULL,
  `TypeName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`EmployeeTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeetype`
--

LOCK TABLES `employeetype` WRITE;
/*!40000 ALTER TABLE `employeetype` DISABLE KEYS */;
INSERT INTO `employeetype` VALUES (1,'พลเรือน'),(2,'พลเรือนในมหาวิทยาลัย'),(3,'ทหาร'),(4,'ตำรวจ'),(5,'ครู'),(6,'อัยการ');
/*!40000 ALTER TABLE `employeetype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estimatedfundmember`
--

DROP TABLE IF EXISTS `estimatedfundmember`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estimatedfundmember` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `FundMemberTypeId` int(11) NOT NULL,
  `EstimatedValue` int(11) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_FundMemberType` (`FundMemberTypeId`),
  CONSTRAINT `FK_FundMemberType` FOREIGN KEY (`FundMemberTypeId`) REFERENCES `fundmembertype` (`FundMemberTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estimatedfundmember`
--

LOCK TABLES `estimatedfundmember` WRITE;
/*!40000 ALTER TABLE `estimatedfundmember` DISABLE KEYS */;
INSERT INTO `estimatedfundmember` VALUES (7,2556,1,1163840,'2013-03-28 22:55:54'),(8,2556,2,134604,'2013-03-28 22:59:48'),(9,2555,1,0,'2013-03-06 23:13:36'),(10,2555,2,0,'2013-03-06 23:13:36'),(11,2554,1,0,'2013-03-07 00:13:43'),(12,2554,2,0,'2013-03-07 00:13:43'),(15,2553,1,0,'2013-03-07 00:25:07'),(16,2553,2,0,'2013-03-07 00:25:07'),(17,2552,1,0,'2013-03-18 08:17:34'),(18,2552,2,0,'2013-03-18 08:17:34'),(19,2551,1,0,'2013-03-18 08:17:40'),(20,2551,2,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `estimatedfundmember` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estimatedretirement`
--

DROP TABLE IF EXISTS `estimatedretirement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estimatedretirement` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `RetirementTypeId` int(11) NOT NULL,
  `EstimatedValue` int(11) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_RetirementType` (`RetirementTypeId`),
  CONSTRAINT `FK_RetirementType` FOREIGN KEY (`RetirementTypeId`) REFERENCES `retirementtype` (`RetirementTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estimatedretirement`
--

LOCK TABLES `estimatedretirement` WRITE;
/*!40000 ALTER TABLE `estimatedretirement` DISABLE KEYS */;
INSERT INTO `estimatedretirement` VALUES (10,2556,1,12143,'2013-03-28 22:35:39'),(11,2556,2,33732,'2013-03-28 22:35:39'),(12,2556,3,6127,'2013-03-28 22:35:39'),(13,2555,1,12193,'2013-04-03 07:37:17'),(14,2555,2,33752,'2013-04-03 07:37:17'),(15,2555,3,6127,'2013-04-03 07:37:17'),(16,2554,1,0,'2013-03-07 00:13:43'),(17,2554,2,0,'2013-03-07 00:13:43'),(18,2554,3,0,'2013-03-07 00:13:43'),(22,2553,1,0,'2013-03-07 00:25:07'),(23,2553,2,0,'2013-03-07 00:25:07'),(24,2553,3,0,'2013-03-07 00:25:07'),(25,2552,1,0,'2013-03-18 08:17:33'),(26,2552,2,0,'2013-03-18 08:17:33'),(27,2552,3,0,'2013-03-18 08:17:33'),(28,2551,1,0,'2013-03-18 08:17:40'),(29,2551,2,0,'2013-03-18 08:17:40'),(30,2551,3,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `estimatedretirement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `firstcarstatus`
--

DROP TABLE IF EXISTS `firstcarstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `firstcarstatus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `StatusTypeId` int(11) NOT NULL,
  `NumberOfPeople` int(11) NOT NULL DEFAULT '0',
  `Amount` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_FirstCarStatusType` (`StatusTypeId`),
  CONSTRAINT `FK_FirstCarStatusType` FOREIGN KEY (`StatusTypeId`) REFERENCES `firstcarstatustype` (`FirstCarStatusTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `firstcarstatus`
--

LOCK TABLES `firstcarstatus` WRITE;
/*!40000 ALTER TABLE `firstcarstatus` DISABLE KEYS */;
INSERT INTO `firstcarstatus` VALUES (7,2556,1,99269,6890,'2013-03-18 08:31:15'),(8,2556,2,253,16,'2013-03-18 08:31:15'),(9,2555,1,31064,2383,'2013-04-10 08:43:10'),(10,2555,2,119,9,'2013-04-10 08:43:10'),(11,2554,1,0,0,'2013-03-07 00:13:43'),(12,2554,2,0,0,'2013-03-07 00:13:43'),(15,2553,1,0,0,'2013-03-07 00:25:07'),(16,2553,2,0,0,'2013-03-07 00:25:07'),(17,2552,1,0,0,'2013-03-18 08:17:34'),(18,2552,2,0,0,'2013-03-18 08:17:34'),(19,2551,1,0,0,'2013-03-18 08:17:40'),(20,2551,2,0,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `firstcarstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `firstcarstatustype`
--

DROP TABLE IF EXISTS `firstcarstatustype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `firstcarstatustype` (
  `FirstCarStatusTypeId` int(11) NOT NULL,
  `StatusName` varchar(255) NOT NULL,
  PRIMARY KEY (`FirstCarStatusTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `firstcarstatustype`
--

LOCK TABLES `firstcarstatustype` WRITE;
/*!40000 ALTER TABLE `firstcarstatustype` DISABLE KEYS */;
INSERT INTO `firstcarstatustype` VALUES (1,'โอนได้'),(2,'โอนไม่ได้');
/*!40000 ALTER TABLE `firstcarstatustype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fundmembertype`
--

DROP TABLE IF EXISTS `fundmembertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fundmembertype` (
  `FundMemberTypeId` int(11) NOT NULL,
  `TypeName` varchar(255) NOT NULL,
  PRIMARY KEY (`FundMemberTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fundmembertype`
--

LOCK TABLES `fundmembertype` WRITE;
/*!40000 ALTER TABLE `fundmembertype` DISABLE KEYS */;
INSERT INTO `fundmembertype` VALUES (1,'สมาชิก กบข.'),(2,'สมาชิก กสจ.');
/*!40000 ALTER TABLE `fundmembertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `numberofemployee`
--

DROP TABLE IF EXISTS `numberofemployee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numberofemployee` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `EmployeeTypeId` int(11) NOT NULL,
  `GovernmentOfficer` int(11) NOT NULL DEFAULT '0',
  `PermanentContractor` int(11) NOT NULL DEFAULT '0',
  `GeneralOfficer` int(11) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_EmployeeType` (`EmployeeTypeId`),
  CONSTRAINT `FK_EmployeeType` FOREIGN KEY (`EmployeeTypeId`) REFERENCES `employeetype` (`EmployeeTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `numberofemployee`
--

LOCK TABLES `numberofemployee` WRITE;
/*!40000 ALTER TABLE `numberofemployee` DISABLE KEYS */;
INSERT INTO `numberofemployee` VALUES (13,2556,1,409524,135978,0,'2013-04-03 04:54:38'),(14,2556,2,36286,10900,0,'2013-04-03 04:54:38'),(15,2556,3,641772,21996,0,'2013-04-03 04:54:38'),(16,2556,4,218328,1242,0,'2013-04-03 04:54:38'),(17,2556,5,458111,0,0,'2013-04-03 04:54:38'),(18,2556,6,3375,266,0,'2013-04-03 04:54:38'),(19,2555,1,409524,135978,0,'2013-04-03 04:48:41'),(20,2555,2,36286,10900,0,'2013-04-03 04:48:41'),(21,2555,3,641772,21996,0,'2013-04-03 04:54:51'),(22,2555,4,218328,1242,0,'2013-04-03 04:48:41'),(23,2555,5,458111,0,0,'2013-04-03 04:48:41'),(24,2555,6,3375,266,0,'2013-04-03 04:48:41'),(25,2554,1,403968,142194,0,'2013-04-03 04:46:42'),(26,2554,2,36490,11583,0,'2013-03-18 08:15:28'),(27,2554,3,609203,21996,0,'2013-03-18 08:15:28'),(28,2554,4,218049,1329,0,'2013-03-18 08:15:28'),(29,2554,5,458240,0,0,'2013-03-18 08:15:28'),(30,2554,6,3387,280,0,'2013-03-18 08:15:28'),(37,2553,1,399659,146011,0,'2013-04-03 04:33:13'),(38,2553,2,49642,12358,0,'2013-03-18 08:23:40'),(39,2553,3,662296,22949,0,'2013-03-18 08:23:40'),(40,2553,4,218006,1404,0,'2013-03-18 08:23:40'),(41,2553,5,458728,0,0,'2013-03-18 08:23:40'),(42,2553,6,3387,283,0,'2013-03-18 08:23:40'),(43,2552,1,400858,157719,0,'2013-03-18 08:21:20'),(44,2552,2,56552,13252,0,'2013-03-18 08:22:27'),(45,2552,3,485412,23761,0,'2013-03-18 08:22:27'),(46,2552,4,217625,1470,0,'2013-03-18 08:22:27'),(47,2552,5,458763,0,0,'2013-03-18 08:22:27'),(48,2552,6,3014,291,0,'2013-03-18 08:22:27'),(49,2551,1,404033,165021,0,'2013-03-18 08:20:43'),(50,2551,2,57938,13844,0,'2013-03-18 08:20:43'),(51,2551,3,514398,24873,0,'2013-03-18 08:20:43'),(52,2551,4,218134,1549,0,'2013-03-18 08:20:43'),(53,2551,5,463361,0,0,'2013-03-18 08:20:43'),(54,2551,6,3027,302,0,'2013-03-18 08:20:43');
/*!40000 ALTER TABLE `numberofemployee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retirementfundtype`
--

DROP TABLE IF EXISTS `retirementfundtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retirementfundtype` (
  `RetirementFundTypeId` int(11) NOT NULL,
  `TypeName` varchar(255) NOT NULL,
  PRIMARY KEY (`RetirementFundTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retirementfundtype`
--

LOCK TABLES `retirementfundtype` WRITE;
/*!40000 ALTER TABLE `retirementfundtype` DISABLE KEYS */;
INSERT INTO `retirementfundtype` VALUES (1,'เบี้ยหวัด'),(2,'บำเหน็จ'),(3,'บำนาญ'),(4,'บำเหน็จดำรงชีพ'),(5,'มาตรการ'),(6,'บำเหน็จลูกจ้าง'),(7,'บำเหน็จตกทอด'),(8,'บำนาญพิเศษ'),(9,'บำเหน็จรายเดือน'),(10,'บำนาญตกทอด'),(11,'เงินทำขวัญ');
/*!40000 ALTER TABLE `retirementfundtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retirementfundusage`
--

DROP TABLE IF EXISTS `retirementfundusage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retirementfundusage` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `RetirementFundTypeId` int(11) NOT NULL,
  `NumberOfPeople` int(11) NOT NULL DEFAULT '0',
  `NumberOfUsage` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_RetirementFundType` (`RetirementFundTypeId`),
  CONSTRAINT `FK_RetirementFundType` FOREIGN KEY (`RetirementFundTypeId`) REFERENCES `retirementfundtype` (`RetirementFundTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retirementfundusage`
--

LOCK TABLES `retirementfundusage` WRITE;
/*!40000 ALTER TABLE `retirementfundusage` DISABLE KEYS */;
INSERT INTO `retirementfundusage` VALUES (23,2556,1,3874,195,'2013-04-04 09:29:02'),(24,2556,2,594,265,'2013-04-04 09:29:02'),(25,2556,3,495097,44474,'2013-04-04 09:29:02'),(26,2556,4,45056,8531,'2013-04-04 09:29:02'),(27,2556,5,20382,9404,'2013-04-04 09:29:02'),(28,2556,6,2243,846,'2013-04-04 09:29:02'),(29,2556,7,5746,2405,'2013-04-04 09:29:02'),(30,2556,8,11939,710,'2013-04-04 09:29:02'),(31,2556,9,22121,1213,'2013-04-04 09:29:03'),(32,2556,10,436,16,'2013-04-04 09:29:03'),(33,2556,11,2,1,'2013-04-04 09:29:20'),(34,2555,1,4018,382,'2013-04-10 09:54:44'),(35,2555,2,857,352,'2013-04-10 09:56:37'),(36,2555,3,463953,82438,'2013-04-10 09:56:37'),(37,2555,4,45299,7921,'2013-04-10 09:58:29'),(38,2555,5,20818,8948,'2013-04-10 09:58:29'),(39,2555,6,3404,1237,'2013-04-10 10:00:26'),(40,2555,7,11197,4776,'2013-04-10 10:00:26'),(41,2555,8,12160,1396,'2013-04-10 10:04:03'),(42,2555,9,15973,1719,'2013-04-10 10:04:03'),(43,2555,10,483,35,'2013-04-10 10:04:03'),(44,2555,11,8,1,'2013-04-10 10:04:03'),(45,2554,1,4124,375,'2013-04-10 10:12:15'),(46,2554,2,823,305,'2013-04-10 10:12:15'),(47,2554,3,437640,78023,'2013-04-10 10:12:15'),(48,2554,4,51248,8900,'2013-04-10 10:12:15'),(49,2554,5,26695,10075,'2013-04-10 10:13:40'),(50,2554,6,3888,1411,'2013-04-10 10:13:40'),(51,2554,7,11349,4420,'2013-04-10 10:26:24'),(52,2554,8,12241,1366,'2013-04-10 10:26:24'),(53,2554,9,9732,1044,'2013-04-10 10:26:24'),(54,2554,10,532,38,'2013-04-10 10:26:54'),(55,2554,11,8,2,'2013-04-10 10:26:54'),(67,2553,1,4333,387,'2013-04-10 10:29:15'),(68,2553,2,1043,379,'2013-04-10 10:29:15'),(69,2553,3,405537,70055,'2013-04-10 10:29:15'),(70,2553,4,51107,8785,'2013-04-10 10:29:15'),(71,2553,5,22551,7905,'2013-04-10 10:29:15'),(72,2553,6,4912,1767,'2013-04-10 10:29:15'),(73,2553,7,12691,4886,'2013-04-10 10:29:15'),(74,2553,8,12010,1314,'2013-04-10 10:29:15'),(75,2553,9,4453,477,'2013-04-10 10:29:15'),(76,2553,10,586,41,'2013-04-10 10:29:15'),(77,2553,11,10,2,'2013-04-10 10:29:15'),(78,2552,1,4073,96,'2013-04-10 10:32:27'),(79,2552,2,137,40,'2013-04-10 10:32:27'),(80,2552,3,369573,16050,'2013-04-10 10:32:27'),(81,2552,4,1945,232,'2013-04-10 10:32:27'),(82,2552,5,12,3,'2013-04-10 10:49:33'),(83,2552,6,244,67,'2013-04-10 10:49:33'),(84,2552,7,1726,579,'2013-04-10 10:49:33'),(85,2552,8,11796,308,'2013-04-10 10:49:33'),(86,2552,9,0,0,'2013-03-18 08:17:33'),(87,2552,10,593,11,'2013-04-10 10:49:33'),(88,2552,11,12,3,'2013-04-10 10:49:33'),(89,2551,1,0,0,'2013-03-18 08:17:40'),(90,2551,2,0,0,'2013-03-18 08:17:40'),(91,2551,3,0,0,'2013-03-18 08:17:40'),(92,2551,4,0,0,'2013-03-18 08:17:40'),(93,2551,5,0,0,'2013-03-18 08:17:40'),(94,2551,6,0,0,'2013-03-18 08:17:40'),(95,2551,7,0,0,'2013-03-18 08:17:40'),(96,2551,8,0,0,'2013-03-18 08:17:40'),(97,2551,9,0,0,'2013-03-18 08:17:40'),(98,2551,10,0,0,'2013-03-18 08:17:40'),(99,2551,11,0,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `retirementfundusage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retirementtype`
--

DROP TABLE IF EXISTS `retirementtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retirementtype` (
  `RetirementTypeId` int(11) NOT NULL,
  `TypeName` varchar(255) NOT NULL,
  PRIMARY KEY (`RetirementTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retirementtype`
--

LOCK TABLES `retirementtype` WRITE;
/*!40000 ALTER TABLE `retirementtype` DISABLE KEYS */;
INSERT INTO `retirementtype` VALUES (1,'ข้าราชการเกษียณปรกติ'),(2,'ข้าราชการเกษียณก่อนกำหนด'),(3,'ลูกจ้างประจำ');
/*!40000 ALTER TABLE `retirementtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` varchar(255) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `SHA1` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Test User','1234','7110eda4d09e062aa5e4a390b0a572ac0d2c0220');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warrantfundprovider`
--

DROP TABLE IF EXISTS `warrantfundprovider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `warrantfundprovider` (
  `WarrantFundProviderId` int(11) NOT NULL,
  `ProviderName` varchar(255) NOT NULL,
  PRIMARY KEY (`WarrantFundProviderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warrantfundprovider`
--

LOCK TABLES `warrantfundprovider` WRITE;
/*!40000 ALTER TABLE `warrantfundprovider` DISABLE KEYS */;
INSERT INTO `warrantfundprovider` VALUES (1,'สรจ.'),(2,'สนง.คลังจังหวัด');
/*!40000 ALTER TABLE `warrantfundprovider` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warrantfundproviding`
--

DROP TABLE IF EXISTS `warrantfundproviding`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `warrantfundproviding` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) NOT NULL,
  `WarrantFundProviderId` int(11) NOT NULL,
  `NumberOfPeople` int(11) NOT NULL DEFAULT '0',
  `Amount` decimal(10,0) NOT NULL DEFAULT '0',
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `FK_WarrantFundProvider` (`WarrantFundProviderId`),
  CONSTRAINT `FK_WarrantFundProvider` FOREIGN KEY (`WarrantFundProviderId`) REFERENCES `warrantfundprovider` (`WarrantFundProviderId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warrantfundproviding`
--

LOCK TABLES `warrantfundproviding` WRITE;
/*!40000 ALTER TABLE `warrantfundproviding` DISABLE KEYS */;
INSERT INTO `warrantfundproviding` VALUES (7,2556,1,2696,1267,'2013-04-03 05:36:07'),(8,2556,2,9212,3629,'2013-04-03 05:36:07'),(9,2555,1,10560,4242,'2013-04-03 05:35:17'),(10,2555,2,34214,11369,'2013-04-03 05:35:17'),(11,2554,1,12187,4771831535,'2013-04-03 05:36:07'),(12,2554,2,56182,17524,'2013-04-03 05:34:18'),(15,2553,1,0,0,'2013-03-07 00:25:07'),(16,2553,2,0,0,'2013-03-07 00:25:07'),(17,2552,1,0,0,'2013-03-18 08:17:33'),(18,2552,2,0,0,'2013-03-18 08:17:33'),(19,2551,1,0,0,'2013-03-18 08:17:40'),(20,2551,2,0,0,'2013-03-18 08:17:40');
/*!40000 ALTER TABLE `warrantfundproviding` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-05-24 18:06:28
