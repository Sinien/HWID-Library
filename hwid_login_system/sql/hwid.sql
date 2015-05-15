CREATE DATABASE IF NOT EXISTS `accounts` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `accounts`;

CREATE TABLE IF NOT EXISTS `keys` (
  `keystring` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(85) NOT NULL,
  `password` varchar(45) NOT NULL,
  `keystring` varchar(12) NOT NULL,
  `hwid` text NOT NULL,
  `status` tinyint(2) NOT NULL,
  PRIMARY KEY (`Id`,`email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

