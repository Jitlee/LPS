/*
Navicat MySQL Data Transfer

Source Server         : loacal
Source Server Version : 50146
Source Host           : localhost:3306
Source Database       : lps

Target Server Type    : MYSQL
Target Server Version : 50146
File Encoding         : 65001

Date: 2013-09-08 09:08:11
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
INSERT INTO `t_base_dictronary` VALUES ('123', '123', '123', null, '123');

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
INSERT INTO `t_base_dictronary_type` VALUES ('123', '一级', 'abc');
INSERT INTO `t_base_dictronary_type` VALUES ('abc', 'abc1', 'abc');

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
INSERT INTO `t_base_empolyee` VALUES ('0b741f01-ad4f-4ade-a5b7-c0f6b2e0da21', 'ab', 'ab', 'ab', '', '男', null, null, '', '', '', '', '', 'ab', 'ab', '2013-09-03', 'N', null);
INSERT INTO `t_base_empolyee` VALUES ('4336dd1b-bbbb-aaaa-000-355a668af000', 'xiaozhu', '', '小猪', null, null, null, null, null, null, null, null, null, '5300100', '123456', '2013-08-31', '0', null);

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
INSERT INTO `t_base_farmer` VALUES ('3206b491-39ec-4757-8109-0301f90e4d2f', '1', '2', '3', '4', '', '', '', '', '男', '2013-09-17', '', '2013-09-06', 'Y', '2013-09-06');

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
INSERT INTO `t_base_leaf_level` VALUES ('BF', '三级', '', '5.00', '7', 'N', null);
INSERT INTO `t_base_leaf_level` VALUES ('BF_X01', '二级', '', '30.00', '1', 'N', null);

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
  `MOD_URL` varchar(512) NOT NULL,
  `MOD_NAME` varchar(64) NOT NULL,
  `PARENT_URL` varchar(512) NOT NULL,
  `SORT` int(11) NOT NULL,
  `MOD_LEVEL` int(11) NOT NULL,
  `MOD_DESC` varchar(256) DEFAULT NULL,
  `ENABLED` char(1) NOT NULL,
  `IMAGE_PATH` varchar(256) DEFAULT NULL,
  `IsFunction` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_function
-- ----------------------------
INSERT INTO `t_sys_function` VALUES ('Main/Default.aspx', '主页', 'root', '0', '0', '烟草管理系统', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/EmpolyeeList.aspx?id=admin', '系统管理', 'Main/Default.aspx', '0', '1', '系统管理', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/EmpolyeeList.aspx', '员工管理', 'Base/EmpolyeeList.aspx?id=admin', '0', '2', '员工管理', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/EmpolyeeEdit.aspx', '编辑', 'Base/EmpolyeeList.aspx', '0', '3', '编辑', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/EmpolyeeList.aspx?Delete', '删除', 'Base/EmpolyeeList.aspx', '1', '3', '删除', 'Y', '', 'Y');
INSERT INTO `t_sys_function` VALUES ('Role/RoleList.aspx', '角色列表', 'Base/EmpolyeeList.aspx?id=admin', '1', '2', '角色列表', 'Y', 'group.gif', 'N');
INSERT INTO `t_sys_function` VALUES ('Role/RoleSet.aspx', '权限设置', 'Role/RoleList.aspx', '0', '3', '权限设置', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Role/RoleEdit.aspx', '编辑', 'Role/RoleList.aspx', '1', '3', '添加、修改角色', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Role/RoleList.aspx?Delete', '删除', 'Role/RoleList.aspx', '2', '3', '删除', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Role/UserAuthList.aspx', '用户授权', 'Base/EmpolyeeList.aspx?id=admin', '2', '2', '给用户授予角色', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Role/UserAuthEdit.aspx', '授权', 'Role/UserAuthList.aspx', '0', '3', '授权授权', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryTypeList.aspx', '数据字典类型列表', 'Base/EmpolyeeList.aspx?id=admin', '3', '2', '数据字典类型列表', 'Y', 'group.gif', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryTypeEdit.aspx', '编辑', 'Base/DictronaryTypeList.aspx', '0', '3', '编辑', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryTypeList.aspx?Delete', '删除', 'Base/DictronaryTypeList.aspx', '1', '3', '删除', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryList.aspx', '数据字典列表', 'Base/EmpolyeeList.aspx?id=admin', '4', '2', '数据字典列表', 'Y', 'group.gif', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryEdit.aspx', '编辑', 'Base/DictronaryList.aspx', '0', '3', '编辑', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/DictronaryList.aspx?Delete', '删除', 'Base/DictronaryList.aspx', '1', '3', '删除', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/FarmerList.aspx', '烟农列表', 'Base/EmpolyeeList.aspx?id=admin', '5', '2', '烟农列表', 'Y', 'group.gif', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/FarmerEdit.aspx', '编辑', 'Base/FarmerList.aspx', '0', '3', '编辑', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/FarmerList.aspx?Delete', '删除', 'Base/FarmerList.aspx', '1', '3', '删除', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/LeafLevelList.aspx', '烟叶等级列表', 'Base/EmpolyeeList.aspx?id=admin', '6', '2', '烟叶等级列表', 'Y', 'group.gif', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/LeafLevelEdit.aspx', '编辑', 'Base/LeafLevelList.aspx', '0', '3', '编辑', 'Y', '', 'N');
INSERT INTO `t_sys_function` VALUES ('Base/LeafLevelList.aspx?Delete', '删除', 'Base/LeafLevelList.aspx', '1', '3', '删除', 'Y', '', 'N');

-- ----------------------------
-- Table structure for `t_sys_permission`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_permission`;
CREATE TABLE `t_sys_permission` (
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
-- Records of t_sys_permission
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
INSERT INTO `t_sys_role` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', '管理员', '管理员');
INSERT INTO `t_sys_role` VALUES ('a1a74765-a621-49a3-8ae4-d6bf0d0c1c57', '一般用户', '执行基础操作');

-- ----------------------------
-- Table structure for `t_sys_role_permission`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_role_permission`;
CREATE TABLE `t_sys_role_permission` (
  `ROLE_ID` varchar(50) NOT NULL COMMENT '角色ID',
  `PERM_CODE` varchar(200) NOT NULL COMMENT '权限编码',
  PRIMARY KEY (`ROLE_ID`,`PERM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色权限表';

-- ----------------------------
-- Records of t_sys_role_permission
-- ----------------------------
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryTypeEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryTypeList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/DictronaryTypeList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/EmpolyeeEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/EmpolyeeList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/EmpolyeeList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/EmpolyeeList.aspx?id=admin');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/FarmerEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/FarmerList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/FarmerList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/LeafLevelEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/LeafLevelList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Base/LeafLevelList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/RoleEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/RoleList.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/RoleList.aspx?Delete');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/RoleSet.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/UserAuthEdit.aspx');
INSERT INTO `t_sys_role_permission` VALUES ('4336dd1b-bf17-4fea-af95-355a668af133', 'Role/UserAuthList.aspx');

-- ----------------------------
-- Table structure for `t_sys_user_permission`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_user_permission`;
CREATE TABLE `t_sys_user_permission` (
  `USER_ID` varchar(36) NOT NULL COMMENT '用户ID',
  `PERM_CODE` varchar(200) NOT NULL COMMENT '权限编码',
  PRIMARY KEY (`USER_ID`,`PERM_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_user_permission
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
INSERT INTO `t_sys_user_role` VALUES ('0b741f01-ad4f-4ade-a5b7-c0f6b2e0da21', '4336dd1b-bf17-4fea-af95-355a668af133');
INSERT INTO `t_sys_user_role` VALUES ('4336dd1b-bbbb-aaaa-000-355a668af000', '4336dd1b-bf17-4fea-af95-355a668af133');

-- ----------------------------
-- View structure for `v_user_permissions`
-- ----------------------------
DROP VIEW IF EXISTS `v_user_permissions`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_user_permissions` AS select distinct `ur`.`USER_ID` AS `USER_ID`,`ur`.`ROLE_ID` AS `ROLE_ID`,`rp`.`PERM_CODE` AS `PERM_CODE`,`f`.`MOD_URL` AS `MOD_URL`,`f`.`MOD_NAME` AS `MOD_NAME`,`f`.`PARENT_URL` AS `PARENT_URL`,`f`.`SORT` AS `SORT`,`f`.`MOD_LEVEL` AS `MOD_LEVEL`,`f`.`MOD_DESC` AS `MOD_DESC`,`f`.`ENABLED` AS `ENABLED`,`f`.`IMAGE_PATH` AS `IMAGE_PATH`,`f`.`IsFunction` AS `isFunction` from ((`t_sys_user_role` `ur` join `t_sys_role_permission` `rp` on((`rp`.`ROLE_ID` = `ur`.`ROLE_ID`))) join `t_sys_function` `f` on((`f`.`MOD_URL` = `rp`.`PERM_CODE`)));

-- ----------------------------
-- Function structure for `F_RoseExisPerm`
-- ----------------------------
DROP FUNCTION IF EXISTS `F_RoseExisPerm`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `F_RoseExisPerm`(`l_RoseID` varchar(36),`l_URL` varchar(256)) RETURNS bit(1)
BEGIN
	#Routine body goes here...
declare l_Result char(1);
declare l_Number int;
	#RETURN l_Result;
RETURN 0;

END
;;
DELIMITER ;
