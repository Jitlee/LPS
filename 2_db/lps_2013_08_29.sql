/*
Navicat MySQL Data Transfer

Source Server         : lps
Source Server Version : 50602
Source Host           : localhost:3306
Source Database       : lps

Target Server Type    : MYSQL
Target Server Version : 50602
File Encoding         : 65001

Date: 2013-08-30 05:01:05
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_base_dictronary`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_dictronary`;
CREATE TABLE `t_base_dictronary` (
  `DICT_TYPE` varchar(50) NOT NULL COMMENT '字典类型',
  `DICT_CODE` varchar(50) NOT NULL,
  `DICT_NAME` varchar(50) NOT NULL COMMENT '字典名称',
  `DICT_VALUE` varchar(200) DEFAULT NULL COMMENT '字典值',
  `DICT_DESC` varchar(100) DEFAULT NULL COMMENT '字典描述',
  PRIMARY KEY (`DICT_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='数据字典表';

-- ----------------------------
-- Records of t_base_dictronary
-- ----------------------------

-- ----------------------------
-- Table structure for `t_base_dictronary_type`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_dictronary_type`;
CREATE TABLE `t_base_dictronary_type` (
  `DICT_TYPE` varchar(50) NOT NULL COMMENT '字典类型',
  `DICT_TYPE_NAME` varchar(50) NOT NULL COMMENT '字典类型名称',
  `DICT_TYPE_DESC` varchar(100) DEFAULT NULL COMMENT '字典类型描述',
  PRIMARY KEY (`DICT_TYPE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='数据字典类型表';

-- ----------------------------
-- Records of t_base_dictronary_type
-- ----------------------------

-- ----------------------------
-- Table structure for `t_base_empolyee`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_empolyee`;
CREATE TABLE `t_base_empolyee` (
  `EMPOLYEE_ID` varchar(36) NOT NULL,
  `EMPOLYEE_CODE` varchar(36) NOT NULL COMMENT '员工编号',
  `EMPOLYEE_RFID` varchar(50) DEFAULT '' COMMENT '员工RFID',
  `EMPOLYEE_NAME` varchar(50) DEFAULT NULL COMMENT '员工名称',
  `EMPOLYEE_PY` varchar(50) DEFAULT NULL COMMENT '员工拼音缩写',
  `EMPOLYEE_SEX` char(1) DEFAULT NULL COMMENT '员工性别(‘男’,’女’)',
  `EMPOLYEE_BIRTH` date DEFAULT NULL COMMENT '员工出生日期',
  `EMPOLYEE_ENTRY_DATE` date DEFAULT NULL COMMENT '员工入职日期',
  `EMPOLYEE_PHONE` varchar(50) DEFAULT NULL COMMENT '员工手机号',
  `EMPOLYEE_EMAIL` varchar(50) DEFAULT NULL COMMENT '员工电子邮箱',
  `EMPOLYEE_ADDRESS` varchar(50) DEFAULT NULL COMMENT '员工联系地址',
  `EMPOLYEE_HOMETOWN` varchar(20) DEFAULT NULL COMMENT '员工籍贯',
  `EMPOLYEE_CARD_ID` varchar(20) DEFAULT NULL COMMENT '员工身份证号',
  `USER_ID` varchar(18) DEFAULT NULL COMMENT '用户ID',
  `USER_PWD` varchar(18) DEFAULT NULL COMMENT '用户密码',
  `EMPOLYEE_CREATE_DATE` date NOT NULL COMMENT '员工创建日期',
  `EMPOLYEE_IS_DELETED` char(1) NOT NULL DEFAULT 'N' COMMENT '表示已删除',
  `EMPOLYEE_DELETED_DATE` date DEFAULT NULL COMMENT '员工删除日期',
  PRIMARY KEY (`EMPOLYEE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工表';

-- ----------------------------
-- Records of t_base_empolyee
-- ----------------------------

-- ----------------------------
-- Table structure for `t_base_farmer`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_farmer`;
CREATE TABLE `t_base_farmer` (
  `FARMER_ID` varchar(36) NOT NULL COMMENT '烟农唯一标识',
  `FARMAR_CODE` varchar(50) NOT NULL COMMENT '烟农编码',
  `FARMER_RFID` varchar(50) DEFAULT NULL COMMENT '烟农RFID标识',
  `FARMER_NAME` varchar(50) DEFAULT NULL COMMENT '烟农名称',
  `FARMER_PY` varchar(50) DEFAULT NULL COMMENT '烟农拼音缩写',
  `FARMER_PHONE` varchar(50) DEFAULT NULL COMMENT '烟农电话',
  `FARMER_EMAIL` varchar(50) DEFAULT NULL COMMENT '烟农电子邮箱',
  `FARMER_ADDRESS` varchar(100) DEFAULT NULL COMMENT '烟农地址',
  `FARMER_RMARK` varchar(100) DEFAULT NULL COMMENT '烟农备注',
  `FARMER_SEX` char(1) DEFAULT NULL,
  `FARMER_BIRTH` date DEFAULT NULL COMMENT '烟农出生日期',
  `FARMER_CARD_ID` varchar(18) DEFAULT NULL,
  `FARMER_CREATE_DATE` date DEFAULT NULL,
  `FARMER_IS_DELETED` char(1) NOT NULL DEFAULT 'N' COMMENT '表示已删除',
  `FARMER_DELETED_DATE` date DEFAULT NULL,
  PRIMARY KEY (`FARMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='烟农表';

-- ----------------------------
-- Records of t_base_farmer
-- ----------------------------

-- ----------------------------
-- Table structure for `t_base_leaf_level`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_leaf_level`;
CREATE TABLE `t_base_leaf_level` (
  `LEAF_LEVEL` varchar(30) NOT NULL DEFAULT '' COMMENT '烟叶等级',
  `LEAF_LEVEL_NAME` varchar(50) DEFAULT NULL COMMENT '烟叶等级名称',
  `LEAF_LEVEL_DESC` varchar(100) DEFAULT NULL COMMENT '烟叶等级描述',
  `LEAF_LEVEL_PRICE` decimal(8,2) DEFAULT NULL COMMENT '烟叶等级价格',
  `LEAF_LEVEL_SORT` int(11) NOT NULL DEFAULT '0' COMMENT '烟叶等级排序',
  `LEAF_LEVEL_IS_DELETED` char(1) NOT NULL DEFAULT 'N' COMMENT '烟叶等级是否删除',
  `LEAF_LEVEL_DELETED_DATE` date DEFAULT NULL COMMENT '烟叶等级删除日期',
  PRIMARY KEY (`LEAF_LEVEL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='烟叶等级表';

-- ----------------------------
-- Records of t_base_leaf_level
-- ----------------------------

-- ----------------------------
-- Table structure for `t_base_parameter`
-- ----------------------------
DROP TABLE IF EXISTS `t_base_parameter`;
CREATE TABLE `t_base_parameter` (
  `PARAM_CODE` varchar(50) NOT NULL COMMENT '参数编码',
  `PARAM_NAME` varchar(50) NOT NULL COMMENT '参数名称',
  `PARAM_VALUE` varchar(200) DEFAULT NULL COMMENT '参数值',
  `PARAM_DESC` varchar(100) DEFAULT NULL COMMENT '参数描述',
  PRIMARY KEY (`PARAM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统参数表';

-- ----------------------------
-- Records of t_base_parameter
-- ----------------------------

-- ----------------------------
-- Table structure for `t_pur_leaf`
-- ----------------------------
DROP TABLE IF EXISTS `t_pur_leaf`;
CREATE TABLE `t_pur_leaf` (
  `LEAF_ID` varchar(36) NOT NULL COMMENT '烟叶ID',
  `LEAF_RFID` varchar(50) DEFAULT NULL COMMENT '烟叶RFID',
  `FARMER_ID` varchar(36) DEFAULT NULL COMMENT '烟农ID',
  `LEAF_DATE` date NOT NULL COMMENT '烟叶标签创建时间',
  `LEAF_LEVEL` varchar(30) DEFAULT NULL COMMENT '烟叶等级',
  `LEAF_LEVEL_DATE` date DEFAULT NULL COMMENT '烟叶等级确认时间',
  `LEAF_LEVEL_EMPOLYEE` varchar(36) DEFAULT NULL COMMENT '烟叶等级确认员工',
  `LEAF_WEIGHT` decimal(8,2) DEFAULT NULL COMMENT '烟叶重量',
  `LEAF_WEIGHT_DATE` date DEFAULT NULL COMMENT '烟叶过磅时间',
  `LEAF_WEIGHT_EMPOLYEE` varchar(36) DEFAULT NULL COMMENT '烟叶过磅员',
  `LEAF_STATE` int(11) NOT NULL DEFAULT '0' COMMENT '烟叶状态',
  `LEAF_IS_DELETED` char(1) NOT NULL DEFAULT 'N' COMMENT '烟叶是否删除',
  `LEAF_DELETED_DATE` date DEFAULT NULL COMMENT '烟叶删除日期',
  PRIMARY KEY (`LEAF_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='烟农和烟叶框的电子标签对应表，此表为流水线表';

-- ----------------------------
-- Records of t_pur_leaf
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_function`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_function`;
CREATE TABLE `t_sys_function` (
  `FUNC_CODE` varchar(200) NOT NULL COMMENT '模块URL',
  `FUNC_NAME` varchar(50) NOT NULL COMMENT '模块名称',
  `FUNC_PARENT_CODE` varchar(200) NOT NULL COMMENT '父模块URL',
  `FUNC_SORT` int(4) NOT NULL DEFAULT '0' COMMENT '排序',
  `FUNC_LEVEL` int(4) DEFAULT '0' COMMENT 'MOD_LEVEL',
  `FUNC_DESC` varchar(100) DEFAULT '模块描述',
  `FUNC_IS_ENABLED` char(1) NOT NULL DEFAULT 'Y' COMMENT '是否可用(Y:可用,N:不可用)',
  PRIMARY KEY (`FUNC_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统功能表';

-- ----------------------------
-- Records of t_sys_function
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_permision`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_permision`;
CREATE TABLE `t_sys_permision` (
  `PERM_CODE` varchar(200) NOT NULL COMMENT '权限编码',
  `FUNC_CODE` varchar(200) NOT NULL COMMENT '模块URL',
  `PERM_NAME` varchar(50) NOT NULL COMMENT '权限名称',
  `PERM_DESC` varchar(100) DEFAULT NULL COMMENT '权限描述',
  `PERM_SORT` int(4) NOT NULL DEFAULT '0' COMMENT 'PERM_SORT',
  `PERM_IS_ENABLED` char(1) NOT NULL DEFAULT 'Y' COMMENT '权限是否可用',
  `PERM_IS_DEFAULT` char(1) NOT NULL DEFAULT 'N' COMMENT '是否为系统默认权限(系统默认权限在重建模块列表时会被删除)',
  PRIMARY KEY (`PERM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='权限表';

-- ----------------------------
-- Records of t_sys_permision
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_role`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_role`;
CREATE TABLE `t_sys_role` (
  `ROLE_ID` varchar(36) NOT NULL COMMENT '角色ID',
  `ROLE_NAME` varchar(50) NOT NULL COMMENT '角色名称',
  `ROLE_DESC` varchar(100) DEFAULT NULL COMMENT '角色描述',
  PRIMARY KEY (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户角色表';

-- ----------------------------
-- Records of t_sys_role
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_role_permision`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_role_permision`;
CREATE TABLE `t_sys_role_permision` (
  `ROLE_ID` varchar(50) NOT NULL COMMENT '角色ID',
  `PERM_CODE` varchar(200) NOT NULL COMMENT '权限编码',
  PRIMARY KEY (`ROLE_ID`,`PERM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色权限表';

-- ----------------------------
-- Records of t_sys_role_permision
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_user_permision`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_user_permision`;
CREATE TABLE `t_sys_user_permision` (
  `USER_ID` varchar(36) NOT NULL COMMENT '用户ID',
  `PERM_CODE` varchar(200) NOT NULL COMMENT '权限编码',
  PRIMARY KEY (`USER_ID`,`PERM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_user_permision
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sys_user_role`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_user_role`;
CREATE TABLE `t_sys_user_role` (
  `USER_ID` varchar(36) NOT NULL COMMENT '用户ID',
  `ROLE_ID` varchar(36) NOT NULL COMMENT '角色ID',
  PRIMARY KEY (`USER_ID`,`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户角色表';

-- ----------------------------
-- Records of t_sys_user_role
-- ----------------------------
