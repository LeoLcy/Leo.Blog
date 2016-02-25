/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2016/2/25 21:34:41                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Sys_AccountInfo') and o.name = 'FK_SYS_ACCO_REFERENCE_SYS_ACCO')
alter table Sys_AccountInfo
   drop constraint FK_SYS_ACCO_REFERENCE_SYS_ACCO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Sys_AccountInfo') and o.name = 'FK_SYS_ACCO_REFERENCE_SYS_ORGI')
alter table Sys_AccountInfo
   drop constraint FK_SYS_ACCO_REFERENCE_SYS_ORGI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Sys_ModuleBtn') and o.name = 'FK_SYS_MODU_REFERENCE_SYS_MODU')
alter table Sys_ModuleBtn
   drop constraint FK_SYS_MODU_REFERENCE_SYS_MODU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Account')
            and   type = 'U')
   drop table Sys_Account
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_AccountInfo')
            and   type = 'U')
   drop table Sys_AccountInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Authorize')
            and   type = 'U')
   drop table Sys_Authorize
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_ModuleBtn')
            and   type = 'U')
   drop table Sys_ModuleBtn
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Modules')
            and   type = 'U')
   drop table Sys_Modules
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_OrgInfo')
            and   type = 'U')
   drop table Sys_OrgInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Roles')
            and   type = 'U')
   drop table Sys_Roles
go

/*==============================================================*/
/* Table: Sys_Account                                           */
/*==============================================================*/
create table Sys_Account (
   Id                   int                  not null,
   Account              varchar(30)          not null,
   Password             varchar(50)          not null,
   IsEnable             int                  not null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_ACCOUNT primary key (Id)
)
go

/*==============================================================*/
/* Table: Sys_AccountInfo                                       */
/*==============================================================*/
create table Sys_AccountInfo (
   Id                   int                  not null,
   OrgId                int                  null,
   Name                 nvarchar(20)         null,
   NickName             nvarchar(20)         null,
   Email                varchar(50)          null,
   TelePhone            varchar(20)          null,
   QQ                   varchar(15)          null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_ACCOUNTINFO primary key (Id)
)
go

/*==============================================================*/
/* Table: Sys_Authorize                                         */
/*==============================================================*/
create table Sys_Authorize (
   Id                   int                  not null,
   AuthFirstId          int                  null,
   AuthSecondId         int                  null,
   AuthType             varchar(20)          null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   constraint PK_SYS_AUTHORIZE primary key (Id)
)
go

/*==============================================================*/
/* Table: Sys_ModuleBtn                                         */
/*==============================================================*/
create table Sys_ModuleBtn (
   BtnId                int                  not null,
   ModuleId             int                  null,
   "DOM ID"             varchar(50)          null,
   BtnName              nvarchar(50)         null,
   BtnType              varchar(10)          null,
   IsEnable             int                  null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_MODULEBTN primary key (BtnId)
)
go

/*==============================================================*/
/* Table: Sys_Modules                                           */
/*==============================================================*/
create table Sys_Modules (
   ModuleId             int                  not null,
   ModuleName           nvarchar(20)         not null,
   ModuleDesc           nvarchar(100)        null,
   WebUrl               varchar(200)         not null,
   ParentModuleId       int                  not null,
   ParentName           nvarchar(20)         not null,
   SortNo               int                  null,
   IsAutoExpend         int                  null,
   IconName             varchar(20)          null,
   IsEnable             int                  not null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_MODULES primary key (ModuleId)
)
go

/*==============================================================*/
/* Table: Sys_OrgInfo                                           */
/*==============================================================*/
create table Sys_OrgInfo (
   OrgId                int                  not null,
   OrgName              nvarchar(20)         not null,
   OrgDesc              nvarchar(100)        null,
   ParentOrgId          int                  not null,
   ParentName           nvarchar(20)         not null,
   OrgPath              varchar(100)         null,
   SortNo               int                  null,
   IsAutoExpend         int                  null,
   IconName             varchar(20)          null,
   IsEnable             int                  not null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_ORGINFO primary key (OrgId)
)
go

/*==============================================================*/
/* Table: Sys_Roles                                             */
/*==============================================================*/
create table Sys_Roles (
   RoleId               int                  not null,
   RoleName             nvarchar(20)         null,
   RoleDesc             nvarchar(100)        null,
   IsEnable             int                  not null,
   CreateBy             int                  null,
   CreateDT             datetime             null,
   LastEditBy           int                  null,
   LastEditDT           datetime             null,
   constraint PK_SYS_ROLES primary key (RoleId)
)
go

alter table Sys_AccountInfo
   add constraint FK_SYS_ACCO_REFERENCE_SYS_ACCO foreign key (Id)
      references Sys_Account (Id)
go

alter table Sys_AccountInfo
   add constraint FK_SYS_ACCO_REFERENCE_SYS_ORGI foreign key (OrgId)
      references Sys_OrgInfo (OrgId)
go

alter table Sys_ModuleBtn
   add constraint FK_SYS_MODU_REFERENCE_SYS_MODU foreign key (ModuleId)
      references Sys_Modules (ModuleId)
go

