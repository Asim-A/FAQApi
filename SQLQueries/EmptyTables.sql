DELETE FROM dbo.categories where category_id > 0;
DELETE FROM sbo.subcategories where subcategory_id > 0;
TRUNCATE TABLE dbo.questions;