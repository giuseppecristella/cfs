<main>
	<section class="catalog-header">
		<header>
			<h1 class="catalog-title">New Arrivals</h1>
			<span class="catalog-subtitle">Stand out from the rest in the perfect clothes</span>
		</header>
	</section><!-- /.catalog-header -->

	<div class="catalog-content">
		<div class="container">
			<!--<div class="right-sidebar">
				<?php //require ROOT . '/parts/widgets/sidebar/sidebar-category.php'; ?>
				<?php //require ROOT . '/parts/widgets/sidebar/sidebar-brand.php'; ?>
				<?php //require ROOT . '/parts/widgets/sidebar/sidebar-filter.php'; ?>
				<div class="free-shipping-ad">Free Standard Shipping <br>at $75</div>
			</div>-->

			<div class="row row-no-margin">
				

				<div class="col-md-9 col-sm-10">
					<div class="control-bar">
						<ul class="breadcrumb">
							<li><a href="index.php?page=home">Home</a></li>
							<li><a href="index.php?page=categories-grid">Men</a></li>
							<li class="active">New Arrivals</li>
						</ul><!-- /.breacrumb -->
						<ul class="listing-options">
							<li class="sort-by">
								<label for="sort-by">Sort by:</label>
								<select id="sort-by">
								    <option value="">Newest</option>
								    <option value="aye">Aye</option>
								    <option value="eh">Eh</option>
								    <option value="ooh">Ooh</option>
								    <option value="whoop">Whoop</option>
								</select>
							</li><!-- /.sort-by -->
							<li class="show-count">
								<select id="no-of-items">
								    <option value="60">60</option>
								    <option value="100">100</option>
								</select>
							</li><!-- /.show-count -->
						</ul><!-- /.listing-options -->
					</div><!-- /.control-bar -->
					<div class="catalog-products clearfix">
						<?php require ROOT . '/parts/section/catalog-products.php';?>
					</div><!-- /.catalog-products -->
				</div>
				<div class="col-md-3 col-sm-2">
					<div class="right-sidebar">
						<?php require ROOT . '/parts/widgets/sidebar/sidebar-category.php'; ?>
						<?php require ROOT . '/parts/widgets/sidebar/sidebar-brand.php'; ?>
						<?php require ROOT . '/parts/widgets/sidebar/sidebar-filter.php'; ?>
						<div class="free-shipping-ad">Free Standard Shipping <br>at $75</div>
					</div><!-- /.right-sidebar -->
				</div><!-- /.col -->
				
			</div><!-- /.row -->

		</div><!-- /.container -->
	</div><!-- /.catalog-content -->
	<?php require ROOT . '/parts/general/pagination.php';?>
</main><!-- /main -->