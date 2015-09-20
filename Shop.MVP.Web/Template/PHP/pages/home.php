<main class="home-1 inner-top-xs">
	<div class="container wow fadeIn">
		<?php require ROOT . '/parts/general/featured-content.php'; ?>
	</div><!-- .container -->

	<div class="brand-holder wow fadeIn">
		<div class="container">
			<?php require ROOT . '/parts/section/home/brand-slider.php'; ?>
		</div><!-- .container -->
	</div><!-- .brand-holder -->

	<div class="new-arrivals-holder wow fadeIn">
		<div class="container">
			<?php require ROOT . '/parts/section/home/new-arrivals.php'; ?>
		</div><!--container-->
		
		<div class="load-more-holder text-center wow fadeIn">
			<a href="index.php?page=categories-grid" class="btn btn-default load-more">Load More Products</a> 
		</div><!--load-more-holder-->
	</div><!--new-arrivals-holder-->

	<div class="blog-holder inner-top-md clearfix wow fadeIn">
		<div class='container'>
			<?php require ROOT . '/parts/section/home/blog-holder.php'; ?>
		</div><!--container-->
	</div><!--blog-holder-->

    <?php require ROOT .'/parts/general/shop-features.php'; ?>
</main>

