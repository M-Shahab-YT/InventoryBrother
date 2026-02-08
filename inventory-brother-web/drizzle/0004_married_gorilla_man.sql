CREATE TABLE `suppliers` (
	`id` text PRIMARY KEY NOT NULL,
	`name` text NOT NULL,
	`contact_person` text,
	`email` text,
	`mobile` text,
	`address` text,
	`status` text DEFAULT 'Active',
	`opening_balance` integer DEFAULT 0,
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1
);
