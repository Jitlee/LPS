CREATE TABLE [dbo].[t_base_empolyee](
	[EMPOLYEE_ID] [varchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[EMPOLYEE_CODE] [varchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[EMPOLYEE_RFID] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''),
	[EMPOLYEE_NAME] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_PY] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_SEX] [char](1) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_BIRTH] [datetime] NULL DEFAULT (NULL),
	[EMPOLYEE_ENTRY_DATE] [datetime] NULL DEFAULT (NULL),
	[EMPOLYEE_PHONE] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_EMAIL] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_ADDRESS] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_HOMETOWN] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_CARD_ID] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[USER_ID] [varchar](18) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[USER_PWD] [varchar](18) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (NULL),
	[EMPOLYEE_CREATE_DATE] [datetime] NOT NULL,
	[EMPOLYEE_IS_DELETED] [char](1) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[EMPOLYEE_DELETED_DATE] [datetime] NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[EMPOLYEE_ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CODE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工RFID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_RFID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_NAME'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工拼音缩写' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_PY'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工性别(‘男’,’女’)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_SEX'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工出生日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_BIRTH'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工入职日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_ENTRY_DATE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工手机号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_PHONE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工电子邮箱' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_EMAIL'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工联系地址' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_ADDRESS'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工籍贯' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_HOMETOWN'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工身份证号' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CARD_ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'USER_ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'USER_PWD'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工创建日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CREATE_DATE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N 表示已删除 ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_IS_DELETED'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工删除日期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_DELETED_DATE'
