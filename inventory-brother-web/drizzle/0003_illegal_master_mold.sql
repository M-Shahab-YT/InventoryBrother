CREATE TABLE `stocks` (
	`id` integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	`product_id` text NOT NULL,
	`warehouse_id` integer NOT NULL,
	`quantity` integer DEFAULT 0,
	`batch_no` text,
	`expiry_date` integer,
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1,
	FOREIGN KEY (`product_id`) REFERENCES `products`(`id`) ON UPDATE no action ON DELETE no action,
	FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses`(`id`) ON UPDATE no action ON DELETE no action
);
--> statement-breakpoint
CREATE TABLE `warehouses` (
	`id` integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	`name` text NOT NULL,
	`address` text,
	`status` text DEFAULT 'Active',
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1
);
