
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/18/2020 00:32:08
-- Generated from EDMX file: C:\Users\hcaip\source\repos\WebPHE\Models\PheDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [phedb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioGenero]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosSet] DROP CONSTRAINT [FK_UsuarioGenero];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioLugNac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosSet] DROP CONSTRAINT [FK_UsuarioLugNac];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuariosLugRes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosSet] DROP CONSTRAINT [FK_UsuariosLugRes];
GO
IF OBJECT_ID(N'[dbo].[FK_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursosSet] DROP CONSTRAINT [FK_Categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Curso_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios_CursosSet] DROP CONSTRAINT [FK_Curso_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Modalidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursosSet] DROP CONSTRAINT [FK_Modalidades];
GO
IF OBJECT_ID(N'[dbo].[FK_TiposCursos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursosSet] DROP CONSTRAINT [FK_TiposCursos];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Curso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios_CursosSet] DROP CONSTRAINT [FK_Usuario_Curso];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsuariosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuariosSet];
GO
IF OBJECT_ID(N'[dbo].[CursosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursosSet];
GO
IF OBJECT_ID(N'[dbo].[Usuarios_CursosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios_CursosSet];
GO
IF OBJECT_ID(N'[dbo].[LugaresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LugaresSet];
GO
IF OBJECT_ID(N'[dbo].[GeneroSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GeneroSet];
GO
IF OBJECT_ID(N'[dbo].[ModalidadesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModalidadesSet];
GO
IF OBJECT_ID(N'[dbo].[TipoCursosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCursosSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriasSet];
GO
IF OBJECT_ID(N'[dbo].[LineasCarrerasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LineasCarrerasSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuariosSet'
CREATE TABLE [dbo].[UsuariosSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombres] nvarchar(50)  NOT NULL,
    [apellidos] nvarchar(50)  NOT NULL,
    [fec_nac] datetime  NOT NULL,
    [id_lug_nac] int  NOT NULL,
    [id_lug_res] int  NOT NULL,
    [id_genero] int  NOT NULL,
    [hobbies] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'CursosSet'
CREATE TABLE [dbo].[CursosSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [titulo] nvarchar(100)  NOT NULL,
    [id_modalidad] int  NOT NULL,
    [duracion] nvarchar(50)  NOT NULL,
    [id_tipo_curso] int  NOT NULL,
    [id_categoria] int  NOT NULL,
    [id_linea_carrera] int  NOT NULL
);
GO

-- Creating table 'Usuarios_CursosSet'
CREATE TABLE [dbo].[Usuarios_CursosSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int  NOT NULL,
    [id_curso] int  NOT NULL,
    [tipo_relacion] smallint  NOT NULL
);
GO

-- Creating table 'LugaresSet'
CREATE TABLE [dbo].[LugaresSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'GeneroSet'
CREATE TABLE [dbo].[GeneroSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'ModalidadesSet'
CREATE TABLE [dbo].[ModalidadesSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TipoCursosSet'
CREATE TABLE [dbo].[TipoCursosSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'CategoriasSet'
CREATE TABLE [dbo].[CategoriasSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'LineasCarrerasSet'
CREATE TABLE [dbo].[LineasCarrerasSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'UsuariosSet'
ALTER TABLE [dbo].[UsuariosSet]
ADD CONSTRAINT [PK_UsuariosSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [PK_CursosSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuarios_CursosSet'
ALTER TABLE [dbo].[Usuarios_CursosSet]
ADD CONSTRAINT [PK_Usuarios_CursosSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LugaresSet'
ALTER TABLE [dbo].[LugaresSet]
ADD CONSTRAINT [PK_LugaresSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'GeneroSet'
ALTER TABLE [dbo].[GeneroSet]
ADD CONSTRAINT [PK_GeneroSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ModalidadesSet'
ALTER TABLE [dbo].[ModalidadesSet]
ADD CONSTRAINT [PK_ModalidadesSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TipoCursosSet'
ALTER TABLE [dbo].[TipoCursosSet]
ADD CONSTRAINT [PK_TipoCursosSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CategoriasSet'
ALTER TABLE [dbo].[CategoriasSet]
ADD CONSTRAINT [PK_CategoriasSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LineasCarrerasSet'
ALTER TABLE [dbo].[LineasCarrerasSet]
ADD CONSTRAINT [PK_LineasCarrerasSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_genero] in table 'UsuariosSet'
ALTER TABLE [dbo].[UsuariosSet]
ADD CONSTRAINT [FK_UsuarioGenero]
    FOREIGN KEY ([id_genero])
    REFERENCES [dbo].[GeneroSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioGenero'
CREATE INDEX [IX_FK_UsuarioGenero]
ON [dbo].[UsuariosSet]
    ([id_genero]);
GO

-- Creating foreign key on [id_lug_nac] in table 'UsuariosSet'
ALTER TABLE [dbo].[UsuariosSet]
ADD CONSTRAINT [FK_UsuarioLugNac]
    FOREIGN KEY ([id_lug_nac])
    REFERENCES [dbo].[LugaresSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioLugNac'
CREATE INDEX [IX_FK_UsuarioLugNac]
ON [dbo].[UsuariosSet]
    ([id_lug_nac]);
GO

-- Creating foreign key on [id_lug_res] in table 'UsuariosSet'
ALTER TABLE [dbo].[UsuariosSet]
ADD CONSTRAINT [FK_UsuariosLugRes]
    FOREIGN KEY ([id_lug_res])
    REFERENCES [dbo].[LugaresSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosLugRes'
CREATE INDEX [IX_FK_UsuariosLugRes]
ON [dbo].[UsuariosSet]
    ([id_lug_res]);
GO

-- Creating foreign key on [id_categoria] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [FK_Categorias]
    FOREIGN KEY ([id_categoria])
    REFERENCES [dbo].[CategoriasSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categorias'
CREATE INDEX [IX_FK_Categorias]
ON [dbo].[CursosSet]
    ([id_categoria]);
GO

-- Creating foreign key on [id_curso] in table 'Usuarios_CursosSet'
ALTER TABLE [dbo].[Usuarios_CursosSet]
ADD CONSTRAINT [FK_Curso_Usuario]
    FOREIGN KEY ([id_curso])
    REFERENCES [dbo].[CursosSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Curso_Usuario'
CREATE INDEX [IX_FK_Curso_Usuario]
ON [dbo].[Usuarios_CursosSet]
    ([id_curso]);
GO

-- Creating foreign key on [id_modalidad] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [FK_Modalidades]
    FOREIGN KEY ([id_modalidad])
    REFERENCES [dbo].[ModalidadesSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Modalidades'
CREATE INDEX [IX_FK_Modalidades]
ON [dbo].[CursosSet]
    ([id_modalidad]);
GO

-- Creating foreign key on [id_tipo_curso] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [FK_TiposCursos]
    FOREIGN KEY ([id_tipo_curso])
    REFERENCES [dbo].[TipoCursosSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiposCursos'
CREATE INDEX [IX_FK_TiposCursos]
ON [dbo].[CursosSet]
    ([id_tipo_curso]);
GO

-- Creating foreign key on [id_usuario] in table 'Usuarios_CursosSet'
ALTER TABLE [dbo].[Usuarios_CursosSet]
ADD CONSTRAINT [FK_Usuario_Curso]
    FOREIGN KEY ([id_usuario])
    REFERENCES [dbo].[UsuariosSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Curso'
CREATE INDEX [IX_FK_Usuario_Curso]
ON [dbo].[Usuarios_CursosSet]
    ([id_usuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------