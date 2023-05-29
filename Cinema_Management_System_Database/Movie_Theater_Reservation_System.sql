Create database [Movies_Management_System]
Go 

Use [Movies_Management_System]
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Movie]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Title] [nvarchar](100) not null,
	[Description] [nvarchar](255) not null,
	[Director] [nvarchar](255) null,
	[Cast] [nvarchar](255) null,
	[Duration] [int] not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Movie] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Insert into Movie (Title, [Description], Director, [Cast], Duration) 
Values ('The Hobbit An Unexpected Journey', 
'Bilbo and company are forced to engage in a war against an array of combatants and keep the Lonely Mountain', 'Peter Jackson', 'Martin Freeman Ian McKellen Richard Armitage', 532);

Select * from Movie;

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Auditorium] 
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Title] [nvarchar](100) not null,
	[SeatsNo] [int] null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Auditorium] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Screening]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[MovieID] UNIQUEIDENTIFIER not null,
	[AuditoriumID] UNIQUEIDENTIFIER not null,
	[ScreeningStart] datetime null,

	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Screening] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Movie-from-Screening] foreign key ([MovieID]) references [Movie](ID),
	
	Constraint [FK-Auditorium-from-Screening] foreign key ([AuditoriumID]) references [Auditorium](ID),

	Constraint [Unique_Index_Screening] unique ([MovieID], [AuditoriumID], [ScreeningStart])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Seats]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Row] [int] not null,
	[Number] [int] not null,
	[AuditoriumID] UNIQUEIDENTIFIER not null,

	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Seats] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Auditorium-from-Seats] foreign key ([AuditoriumID]) references [Auditorium](ID),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [ReservationType]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[ReservationTypes] [nvarchar](100) not null,

	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Reservation_type] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Employee]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[FirstName] [nvarchar](100) not null,
	[LastName] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Mobile] [nvarchar](255) null,

	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),

	Constraint [PK-Employee] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Roles]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[RoleTitle] [nvarchar](100) not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),
	
	Constraint [PK-Roles] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Role_title] unique ([RoleTitle])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [HasRoles]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[EmployeeID] UNIQUEIDENTIFIER not null,
	[RolesID] UNIQUEIDENTIFIER not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),

	Constraint [PK-Has-Role] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Has-Role-to-Employees] Foreign key ([EmployeeID]) references [Employee]([ID]),
	
	Constraint [FK-Role-Has-to-Roles] Foreign key ([RolesID]) references [Roles]([ID]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Reservation]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[EmployeeID] UNIQUEIDENTIFIER not null,
	[ScreeningID] UNIQUEIDENTIFIER not null,
	[ReservationTypeID] UNIQUEIDENTIFIER not null,
	[Reserved] bit not null default 0,
	[Paid] bit not null default 0,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),

	Constraint [PK-Reservation] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Reservation-to-Employees] Foreign key ([EmployeeID]) references [Employee]([ID]),
	
	Constraint [FK-Reservation-to-Screening] Foreign key ([ScreeningID]) references [Screening]([ID]),

	Constraint [FK-Reservation-to-Reservation_type] Foreign key ([ReservationTypeID]) references [ReservationType]([ID]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [SeatReserves]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[SeatID] UNIQUEIDENTIFIER not null,
	[ScreeningID] UNIQUEIDENTIFIER not null,
	[ReservationID] UNIQUEIDENTIFIER not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default GETDATE(),

	Constraint [PK-Reservation_Sear] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Seat_Reservation-to-Employees] Foreign key ([SeatID]) references [Seats]([ID]),
	
	Constraint [FK-Seat_Reservation-to-Screening] Foreign key ([ScreeningID]) references [Screening]([ID]),

	Constraint [FK-Seat_Reservation-to-Reservation_type] Foreign key ([ReservationID]) references [Reservation]([ID]),
)
Go




