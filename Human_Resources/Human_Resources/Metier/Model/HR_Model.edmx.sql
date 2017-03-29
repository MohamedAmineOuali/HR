
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2017 19:06:00
-- Generated from EDMX file: D:\Windows Files\Phenix\Documents\ppp\Project\Human_Resources\Human_Resources\Metier\Model\HR_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HumanResources];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Conge__FK_TypeCo__35BCFE0A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Conges] DROP CONSTRAINT [FK__Conge__FK_TypeCo__35BCFE0A];
GO
IF OBJECT_ID(N'[dbo].[FK__Contrat__FK_Cate__30F848ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contrats] DROP CONSTRAINT [FK__Contrat__FK_Cate__30F848ED];
GO
IF OBJECT_ID(N'[dbo].[FK__Contrat__FK_Type__300424B4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contrats] DROP CONSTRAINT [FK__Contrat__FK_Type__300424B4];
GO
IF OBJECT_ID(N'[dbo].[FK__PrimesVar__FK_Em__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrimesVariables] DROP CONSTRAINT [FK__PrimesVar__FK_Em__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK_Categorie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prime_Categorie] DROP CONSTRAINT [FK_Categorie];
GO
IF OBJECT_ID(N'[dbo].[FK_Chef]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Departements] DROP CONSTRAINT [FK_Chef];
GO
IF OBJECT_ID(N'[dbo].[FK_CompteEmploye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comptes] DROP CONSTRAINT [FK_CompteEmploye];
GO
IF OBJECT_ID(N'[dbo].[FK_Contrat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employes] DROP CONSTRAINT [FK_Contrat];
GO
IF OBJECT_ID(N'[dbo].[FK_Departement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employes] DROP CONSTRAINT [FK_Departement];
GO
IF OBJECT_ID(N'[dbo].[FK_Employe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Conges] DROP CONSTRAINT [FK_Employe];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeBDP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BulletinDePaies] DROP CONSTRAINT [FK_EmployeBDP];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeCat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avances] DROP CONSTRAINT [FK_EmployeCat];
GO
IF OBJECT_ID(N'[dbo].[FK_Etablissement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Departements] DROP CONSTRAINT [FK_Etablissement];
GO
IF OBJECT_ID(N'[dbo].[FK_InfosBanque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employes] DROP CONSTRAINT [FK_InfosBanque];
GO
IF OBJECT_ID(N'[dbo].[FK_PrimeFixe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prime_Categorie] DROP CONSTRAINT [FK_PrimeFixe];
GO
IF OBJECT_ID(N'[dbo].[FK_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comptes] DROP CONSTRAINT [FK_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Avances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avances];
GO
IF OBJECT_ID(N'[dbo].[BulletinDePaies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BulletinDePaies];
GO
IF OBJECT_ID(N'[dbo].[Categories1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories1];
GO
IF OBJECT_ID(N'[dbo].[ChargePatronales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChargePatronales];
GO
IF OBJECT_ID(N'[dbo].[CNAMs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CNAMs];
GO
IF OBJECT_ID(N'[dbo].[CNRPS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CNRPS];
GO
IF OBJECT_ID(N'[dbo].[CNSSes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CNSSes];
GO
IF OBJECT_ID(N'[dbo].[Comptes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comptes];
GO
IF OBJECT_ID(N'[dbo].[Conges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conges];
GO
IF OBJECT_ID(N'[dbo].[Contrats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contrats];
GO
IF OBJECT_ID(N'[dbo].[Departements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departements];
GO
IF OBJECT_ID(N'[dbo].[Employes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employes];
GO
IF OBJECT_ID(N'[dbo].[Etablissements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Etablissements];
GO
IF OBJECT_ID(N'[dbo].[IGRs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IGRs];
GO
IF OBJECT_ID(N'[dbo].[InfosBanques]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfosBanques];
GO
IF OBJECT_ID(N'[dbo].[LivreDePaies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LivreDePaies];
GO
IF OBJECT_ID(N'[dbo].[Prime_Categorie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prime_Categorie];
GO
IF OBJECT_ID(N'[dbo].[PrimeFixes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrimeFixes];
GO
IF OBJECT_ID(N'[dbo].[PrimesVariables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrimesVariables];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[TypeConges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeConges];
GO
IF OBJECT_ID(N'[dbo].[TypeContrats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeContrats];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Avances'
CREATE TABLE [dbo].[Avances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateVersement] datetime  NULL,
    [Mois] datetime  NULL,
    [Montant] decimal(18,0)  NULL,
    [FK_Employe] int  NOT NULL
);
GO

-- Creating table 'BulletinDePaies'
CREATE TABLE [dbo].[BulletinDePaies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CNSS] decimal(18,0)  NULL,
    [Conges] int  NULL,
    [DatePrime] datetime  NULL,
    [HeuresDeTravail] int  NULL,
    [Nb_H_Ajout] int  NULL,
    [Nb_H_Retard] int  NULL,
    [Net_A_Payer] decimal(18,0)  NULL,
    [Prime_Presence] decimal(18,0)  NULL,
    [Salaire_Base] decimal(18,0)  NULL,
    [Salaire_Brute] decimal(18,0)  NULL,
    [Statut] nvarchar(50)  NULL,
    [FK_Employe] int  NOT NULL
);
GO

-- Creating table 'Categories1'
CREATE TABLE [dbo].[Categories1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Informations] nvarchar(50)  NULL,
    [Libelle] nvarchar(50)  NULL
);
GO

-- Creating table 'ChargePatronales'
CREATE TABLE [dbo].[ChargePatronales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CNRPS] decimal(18,0)  NULL,
    [CNSS] decimal(18,0)  NULL,
    [IGR] decimal(18,0)  NULL,
    [Mois] datetime  NULL,
    [Salaires] decimal(18,0)  NULL
);
GO

-- Creating table 'CNAMs'
CREATE TABLE [dbo].[CNAMs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TauxPatronal] decimal(18,0)  NULL,
    [TauxSalarial] decimal(18,0)  NULL,
    [Type] nvarchar(50)  NULL
);
GO

-- Creating table 'CNRPS'
CREATE TABLE [dbo].[CNRPS] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TauxPatronal] decimal(18,0)  NULL,
    [TauxSalarial] decimal(18,0)  NULL
);
GO

-- Creating table 'CNSSes'
CREATE TABLE [dbo].[CNSSes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlafondSalarial] decimal(18,0)  NULL,
    [TauxPatronal] decimal(18,0)  NULL,
    [TauxSalarial] decimal(18,0)  NULL
);
GO

-- Creating table 'Comptes'
CREATE TABLE [dbo].[Comptes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [FK_Employe] int  NOT NULL,
    [FK_Role] int  NOT NULL
);
GO

-- Creating table 'Conges'
CREATE TABLE [dbo].[Conges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateDebut] datetime  NULL,
    [DateDemande] datetime  NULL,
    [NbreJours] int  NULL,
    [Etat] nvarchar(50)  NULL,
    [FK_TypeConge] int  NOT NULL,
    [FK_Employe] int  NOT NULL
);
GO

-- Creating table 'Contrats'
CREATE TABLE [dbo].[Contrats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] nchar(10)  NULL,
    [DateDebut] datetime  NULL,
    [DateFin] datetime  NULL,
    [FK_TypeContrat] int  NOT NULL,
    [FK_Categorie] int  NOT NULL
);
GO

-- Creating table 'Departements'
CREATE TABLE [dbo].[Departements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NULL,
    [Libelle] nvarchar(50)  NULL,
    [NbreEmployes] varbinary(max)  NULL,
    [Numero] int  NULL,
    [FK_Etablissement] int  NOT NULL,
    [FK_Chef] int  NULL
);
GO

-- Creating table 'Employes'
CREATE TABLE [dbo].[Employes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(50)  NULL,
    [Addresse] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL,
    [NbreEnfants] int  NULL,
    [LieuDeNaissance] nvarchar(50)  NULL,
    [DateDeNaissance] datetime  NULL,
    [CIN] int  NULL,
    [Matricule] int  NULL,
    [StatutSocial] nvarchar(50)  NULL,
    [Telephone] int  NULL,
    [Natonalite] nchar(10)  NULL,
    [Num_SecuriteSociale] int  NULL,
    [Grade] nvarchar(50)  NULL,
    [Genre] nvarchar(50)  NULL,
    [Etat] nvarchar(50)  NULL,
    [FK_InfosBanque] int  NOT NULL,
    [FK_Contrat] int  NOT NULL,
    [FK_Departement] int  NULL
);
GO

-- Creating table 'Etablissements'
CREATE TABLE [dbo].[Etablissements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Localite] nvarchar(50)  NULL,
    [MaxEmploye] int  NULL,
    [Type] nvarchar(50)  NULL
);
GO

-- Creating table 'IGRs'
CREATE TABLE [dbo].[IGRs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SalaireMax] decimal(18,0)  NULL,
    [SalaireMin] decimal(18,0)  NULL,
    [Taux] decimal(18,0)  NULL
);
GO

-- Creating table 'InfosBanques'
CREATE TABLE [dbo].[InfosBanques] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroCompte] nvarchar(50)  NULL,
    [TelBanque] int  NULL,
    [CodeBanque] int  NULL,
    [Domiciliation] nvarchar(50)  NULL,
    [CodeGuichet] int  NULL,
    [ReglementPar] nvarchar(max)  NULL,
    [CleRIB] int  NULL,
    [IBAN] varchar(50)  NULL
);
GO

-- Creating table 'LivreDePaies'
CREATE TABLE [dbo].[LivreDePaies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mois] datetime  NULL,
    [Reference] nvarchar(50)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'Prime_Categorie'
CREATE TABLE [dbo].[Prime_Categorie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FK_Categorie] int  NOT NULL,
    [FK_PrimeFixe] int  NOT NULL
);
GO

-- Creating table 'PrimeFixes'
CREATE TABLE [dbo].[PrimeFixes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [Valeur] decimal(18,0)  NULL,
    [Exoneres] nvarchar(50)  NULL
);
GO

-- Creating table 'PrimesVariables'
CREATE TABLE [dbo].[PrimesVariables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [Valeur] decimal(18,0)  NULL,
    [Exoneres] nvarchar(50)  NULL,
    [DateAffectation] datetime  NULL,
    [FK_Employe] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(50)  NULL,
    [Privileges] nvarchar(max)  NULL
);
GO

-- Creating table 'TypeConges'
CREATE TABLE [dbo].[TypeConges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(50)  NULL
);
GO

-- Creating table 'TypeContrats'
CREATE TABLE [dbo].[TypeContrats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Details] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Avances'
ALTER TABLE [dbo].[Avances]
ADD CONSTRAINT [PK_Avances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BulletinDePaies'
ALTER TABLE [dbo].[BulletinDePaies]
ADD CONSTRAINT [PK_BulletinDePaies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories1'
ALTER TABLE [dbo].[Categories1]
ADD CONSTRAINT [PK_Categories1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChargePatronales'
ALTER TABLE [dbo].[ChargePatronales]
ADD CONSTRAINT [PK_ChargePatronales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CNAMs'
ALTER TABLE [dbo].[CNAMs]
ADD CONSTRAINT [PK_CNAMs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CNRPS'
ALTER TABLE [dbo].[CNRPS]
ADD CONSTRAINT [PK_CNRPS]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CNSSes'
ALTER TABLE [dbo].[CNSSes]
ADD CONSTRAINT [PK_CNSSes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comptes'
ALTER TABLE [dbo].[Comptes]
ADD CONSTRAINT [PK_Comptes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Conges'
ALTER TABLE [dbo].[Conges]
ADD CONSTRAINT [PK_Conges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contrats'
ALTER TABLE [dbo].[Contrats]
ADD CONSTRAINT [PK_Contrats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departements'
ALTER TABLE [dbo].[Departements]
ADD CONSTRAINT [PK_Departements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employes'
ALTER TABLE [dbo].[Employes]
ADD CONSTRAINT [PK_Employes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Etablissements'
ALTER TABLE [dbo].[Etablissements]
ADD CONSTRAINT [PK_Etablissements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IGRs'
ALTER TABLE [dbo].[IGRs]
ADD CONSTRAINT [PK_IGRs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InfosBanques'
ALTER TABLE [dbo].[InfosBanques]
ADD CONSTRAINT [PK_InfosBanques]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LivreDePaies'
ALTER TABLE [dbo].[LivreDePaies]
ADD CONSTRAINT [PK_LivreDePaies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prime_Categorie'
ALTER TABLE [dbo].[Prime_Categorie]
ADD CONSTRAINT [PK_Prime_Categorie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrimeFixes'
ALTER TABLE [dbo].[PrimeFixes]
ADD CONSTRAINT [PK_PrimeFixes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrimesVariables'
ALTER TABLE [dbo].[PrimesVariables]
ADD CONSTRAINT [PK_PrimesVariables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeConges'
ALTER TABLE [dbo].[TypeConges]
ADD CONSTRAINT [PK_TypeConges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeContrats'
ALTER TABLE [dbo].[TypeContrats]
ADD CONSTRAINT [PK_TypeContrats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FK_Employe] in table 'Avances'
ALTER TABLE [dbo].[Avances]
ADD CONSTRAINT [FK_EmployeCat]
    FOREIGN KEY ([FK_Employe])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeCat'
CREATE INDEX [IX_FK_EmployeCat]
ON [dbo].[Avances]
    ([FK_Employe]);
GO

-- Creating foreign key on [FK_Employe] in table 'BulletinDePaies'
ALTER TABLE [dbo].[BulletinDePaies]
ADD CONSTRAINT [FK_EmployeBDP]
    FOREIGN KEY ([FK_Employe])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeBDP'
CREATE INDEX [IX_FK_EmployeBDP]
ON [dbo].[BulletinDePaies]
    ([FK_Employe]);
GO

-- Creating foreign key on [FK_Categorie] in table 'Contrats'
ALTER TABLE [dbo].[Contrats]
ADD CONSTRAINT [FK__Contrat__FK_Cate__30F848ED]
    FOREIGN KEY ([FK_Categorie])
    REFERENCES [dbo].[Categories1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contrat__FK_Cate__30F848ED'
CREATE INDEX [IX_FK__Contrat__FK_Cate__30F848ED]
ON [dbo].[Contrats]
    ([FK_Categorie]);
GO

-- Creating foreign key on [FK_Categorie] in table 'Prime_Categorie'
ALTER TABLE [dbo].[Prime_Categorie]
ADD CONSTRAINT [FK_Categorie]
    FOREIGN KEY ([FK_Categorie])
    REFERENCES [dbo].[Categories1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categorie'
CREATE INDEX [IX_FK_Categorie]
ON [dbo].[Prime_Categorie]
    ([FK_Categorie]);
GO

-- Creating foreign key on [FK_Employe] in table 'Comptes'
ALTER TABLE [dbo].[Comptes]
ADD CONSTRAINT [FK_CompteEmploye]
    FOREIGN KEY ([FK_Employe])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompteEmploye'
CREATE INDEX [IX_FK_CompteEmploye]
ON [dbo].[Comptes]
    ([FK_Employe]);
GO

-- Creating foreign key on [FK_Role] in table 'Comptes'
ALTER TABLE [dbo].[Comptes]
ADD CONSTRAINT [FK_Role]
    FOREIGN KEY ([FK_Role])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Role'
CREATE INDEX [IX_FK_Role]
ON [dbo].[Comptes]
    ([FK_Role]);
GO

-- Creating foreign key on [FK_TypeConge] in table 'Conges'
ALTER TABLE [dbo].[Conges]
ADD CONSTRAINT [FK__Conge__FK_TypeCo__35BCFE0A]
    FOREIGN KEY ([FK_TypeConge])
    REFERENCES [dbo].[TypeConges]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Conge__FK_TypeCo__35BCFE0A'
CREATE INDEX [IX_FK__Conge__FK_TypeCo__35BCFE0A]
ON [dbo].[Conges]
    ([FK_TypeConge]);
GO

-- Creating foreign key on [FK_Employe] in table 'Conges'
ALTER TABLE [dbo].[Conges]
ADD CONSTRAINT [FK_Employe]
    FOREIGN KEY ([FK_Employe])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employe'
CREATE INDEX [IX_FK_Employe]
ON [dbo].[Conges]
    ([FK_Employe]);
GO

-- Creating foreign key on [FK_TypeContrat] in table 'Contrats'
ALTER TABLE [dbo].[Contrats]
ADD CONSTRAINT [FK__Contrat__FK_Type__300424B4]
    FOREIGN KEY ([FK_TypeContrat])
    REFERENCES [dbo].[TypeContrats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contrat__FK_Type__300424B4'
CREATE INDEX [IX_FK__Contrat__FK_Type__300424B4]
ON [dbo].[Contrats]
    ([FK_TypeContrat]);
GO

-- Creating foreign key on [FK_Contrat] in table 'Employes'
ALTER TABLE [dbo].[Employes]
ADD CONSTRAINT [FK_Contrat]
    FOREIGN KEY ([FK_Contrat])
    REFERENCES [dbo].[Contrats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contrat'
CREATE INDEX [IX_FK_Contrat]
ON [dbo].[Employes]
    ([FK_Contrat]);
GO

-- Creating foreign key on [FK_Chef] in table 'Departements'
ALTER TABLE [dbo].[Departements]
ADD CONSTRAINT [FK_Chef]
    FOREIGN KEY ([FK_Chef])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Chef'
CREATE INDEX [IX_FK_Chef]
ON [dbo].[Departements]
    ([FK_Chef]);
GO

-- Creating foreign key on [FK_Departement] in table 'Employes'
ALTER TABLE [dbo].[Employes]
ADD CONSTRAINT [FK_Departement]
    FOREIGN KEY ([FK_Departement])
    REFERENCES [dbo].[Departements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Departement'
CREATE INDEX [IX_FK_Departement]
ON [dbo].[Employes]
    ([FK_Departement]);
GO

-- Creating foreign key on [FK_Etablissement] in table 'Departements'
ALTER TABLE [dbo].[Departements]
ADD CONSTRAINT [FK_Etablissement]
    FOREIGN KEY ([FK_Etablissement])
    REFERENCES [dbo].[Etablissements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Etablissement'
CREATE INDEX [IX_FK_Etablissement]
ON [dbo].[Departements]
    ([FK_Etablissement]);
GO

-- Creating foreign key on [FK_Employe] in table 'PrimesVariables'
ALTER TABLE [dbo].[PrimesVariables]
ADD CONSTRAINT [FK__PrimesVar__FK_Em__48CFD27E]
    FOREIGN KEY ([FK_Employe])
    REFERENCES [dbo].[Employes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PrimesVar__FK_Em__48CFD27E'
CREATE INDEX [IX_FK__PrimesVar__FK_Em__48CFD27E]
ON [dbo].[PrimesVariables]
    ([FK_Employe]);
GO

-- Creating foreign key on [FK_InfosBanque] in table 'Employes'
ALTER TABLE [dbo].[Employes]
ADD CONSTRAINT [FK_InfosBanque]
    FOREIGN KEY ([FK_InfosBanque])
    REFERENCES [dbo].[InfosBanques]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InfosBanque'
CREATE INDEX [IX_FK_InfosBanque]
ON [dbo].[Employes]
    ([FK_InfosBanque]);
GO

-- Creating foreign key on [FK_PrimeFixe] in table 'Prime_Categorie'
ALTER TABLE [dbo].[Prime_Categorie]
ADD CONSTRAINT [FK_PrimeFixe]
    FOREIGN KEY ([FK_PrimeFixe])
    REFERENCES [dbo].[PrimeFixes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrimeFixe'
CREATE INDEX [IX_FK_PrimeFixe]
ON [dbo].[Prime_Categorie]
    ([FK_PrimeFixe]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------