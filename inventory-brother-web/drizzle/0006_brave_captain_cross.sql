CREATE TABLE `customers` (
	`id` text PRIMARY KEY NOT NULL,
	`name` text NOT NULL,
	`mobile` text,
	`email` text,
	`address` text,
	`type` text DEFAULT 'Retail',
	`contact_person` text,
	`status` text DEFAULT 'Active',
	`area_code` text,
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1
);
