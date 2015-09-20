<main class="single-page">
 	<div class="breadcrumb-holder">
		<div class="container">
			<ul class="breadcrumb pull-left">
				<li><a href="index.php?page=home">Home</a></li>
				<li><a href="index.php?page=categories-grid">Men</a></li>
				<li><a href="index.php?page=catalog">New Arrivals</a></li>
				<li class='active'>Converse Chuck Taylor</li>
			</ul><!--breadcrumb-->

			<div class="nav-links clearfix">
				<a href="index.php?page=product-extended" class="prev"><i class="icon icon-pagination-left icon-prev"></i>Previous</a>
				<a href="index.php?page=product-extended" class="next">Next<i class="icon icon-pagination-right icon-next"></i></a>
			</div><!--nav-links-->
		</div><!--container-->
	</div><!--breadcrumb-holder-->
	 <?php require_once ROOT.'/parts/product-simple/primary-block.php'; ?>
	 <?php require_once ROOT.'/parts/products/single-product-tab.php'; ?>	
</main><!--single-page-->