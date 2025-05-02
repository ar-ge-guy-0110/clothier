SELECT cloth_category.category_name, cloth_which_category.cloth_category_id FROM cloth_category 
JOIN cloth_which_category ON cloth_which_category.cloth_category_id = cloth_category.id 
JOIN cloth ON cloth_which_category.cloth_id = cloth.id WHERE cloth.id = 
