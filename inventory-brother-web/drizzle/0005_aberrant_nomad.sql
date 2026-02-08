CREATE TABLE `purchase_order_items` (
	`id` integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	`purchase_order_id` text NOT NULL,
	`product_id` text NOT NULL,
	`quantity` integer DEFAULT 0,
	`unit_cost` integer DEFAULT 0,
	`total_cost` integer DEFAULT 0,
	`batch_no` text,
	`expiry_date` integer,
	FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_orders`(`id`) ON UPDATE no action ON DELETE cascade,
	FOREIGN KEY (`product_id`) REFERENCES `products`(`id`) ON UPDATE no action ON DELETE no action
);
--> statement-breakpoint
CREATE TABLE `purchase_orders` (
	`id` text PRIMARY KEY NOT NULL,
	`purchase_order_no` text NOT NULL,
	`supplier_id` text,
	`order_date` integer DEFAULT (strftime('%s', 'now')),
	`status` text DEFAULT 'Draft',
	`total_amount` integer DEFAULT 0,
	`remarks` text,
	`created_at` integer DEFAULT (strftime('%s', 'now')),
	`updated_at` integer,
	`created_by` text,
	`updated_by` text,
	`store_id` integer DEFAULT 1,
	FOREIGN KEY (`supplier_id`) REFERENCES `suppliers`(`id`) ON UPDATE no action ON DELETE no action
);
--> statement-breakpoint
CREATE UNIQUE INDEX `purchase_orders_purchase_order_no_unique` ON `purchase_orders` (`purchase_order_no`);