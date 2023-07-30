create table cars (
	id bigint generated always as identity primary key,
	name varchar(50),
	model varchar(50),
	status text,
	image_path text,
	price_of_date real,
	description text,
	created_at timestamp with time zone,
	updated_at timestamp with time zone
);

create table rentals (
	id bigint generated always as identity primary key,
	days int,
	destination text,
	payment_type text,
	is_payment bool,
	description text,
	created_at timestamp with time zone,
	updated_at timestamp with time zone
);

create table clients (
	id bigint generated always as identity primary key,
	first_name varchar(50),
	last_name varchar(50),
	phone_number varchar(13),
	drivers_license text,
	is_male bool,
	image_path text,
	password_hash text,
	salt text,
	role text,
	description text,
	created_at timestamp with time zone,
	updated_at timestamp with time zone
);

create table transactions (
	id bigint generated always as identity primary key,
	car_id bigint references cars(id),
	client_id bigint references clients(id),
	rental_id bigint references rentals(id),
	total_price real,
	description text,
	created_at timestamp with time zone,
	updated_at timestamp with time zone
);