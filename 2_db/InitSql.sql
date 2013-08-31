insert into t_sys_role values('4336dd1b-bf17-4fea-af95-355a668af133','普通用户','普通用户' )
insert into T_SYS_ROLE_PERMISSION select '4336dd1b-bf17-4fea-af95-355a668af133',MOD_URL from T_SYS_Function

insert into t_base_empolyee(EMPOLYEE_ID,EMPOLYEE_CODE,USER_ID,USER_PWD,EMPOLYEE_CREATE_DATE,EMPOLYEE_IS_DELETED) values('4336dd1b-bbbb-aaaa-000-355a668af000','xiaozhu','5300100','123456',NOW(),0)
insert into  T_SYS_USER_ROLE values('4336dd1b-bbbb-aaaa-000-355a668af000','4336dd1b-bf17-4fea-af95-355a668af133');