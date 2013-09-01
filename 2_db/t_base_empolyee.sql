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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CODE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա��RFID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_RFID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_NAME'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա��ƴ����д' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_PY'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա���Ա�(���С�,��Ů��)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_SEX'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_BIRTH'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����ְ����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_ENTRY_DATE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա���ֻ���' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_PHONE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_EMAIL'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����ϵ��ַ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_ADDRESS'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_HOMETOWN'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա�����֤��' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CARD_ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'USER_ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'USER_PWD'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_CREATE_DATE'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N ��ʾ��ɾ�� ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_IS_DELETED'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա��ɾ������' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_base_empolyee', @level2type=N'COLUMN', @level2name=N'EMPOLYEE_DELETED_DATE'
