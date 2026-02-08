CREATE TABLE `sale_items` (
	`id` integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	`sale_id` text NOT NULL,
	`product_id` text NOT NULL,
	`quantity` integer DEFAULT 0,
	`unit_price` integer DEFAULT 0,
	`total` integer DEFAULT 0,
	`cost_price` integer DEFAULT 0,
	FOREIGN KEY (`sale_id`) REFERENCES `sales`(`id`) ON UPDATE no action ON DELETE cascade,
	FOREIGN KEY (`product_id`) REFERENCES `products`(`id`) ON UPDATE no action ON DELETE no action
);
--> statement-breakpoint
CREATE TABLE `sales` (
	`id` text PRIMARY KEY NOT NULL,
	`invoice_no` text NOT NULL,
	`customer_id` text,
	`sale_date` integer DEFAULT (strftime('%s', 'now')),
	`total_amount` integer DEFAULT 0,
	`discount` integer DEFAULT 0,
	`tax` integer DEFAULT 0,
	`net_amount` integer DEFAULT 0,
	`payment_method` text DEFAULT 'Cash',
	`status` text DEFAULT 'Completed',
	`warehouse_id` integer,
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1,
	FOREIGN KEY (`customer_id`) REFERENCES `customers`(`id`) ON UPDATE no action ON DELETE no action,
	FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses`(`id`) ON UPDATE no action ON DELETE no action
);
--> statement-breakpoint
CREATE UNIQUE INDEX `sales_invoice_no_unique` ON `sales` (`invoice_no`);