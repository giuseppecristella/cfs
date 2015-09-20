<?php
$sliders = array(
	1 => array(
		'full_image' => 'assets/images/products/f1.jpg',
		'top_left' => array(
			'image' => 'assets/images/products/1.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'top_right' => array(
			'image' => 'assets/images/products/2.jpg',
			'title'	=> 'Tote Handbag',
			'price' => '$350',
			),
		'bottom_left' => array(
			'image' => 'assets/images/products/3.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'bottom_right' => array(
			'image' => 'assets/images/products/4.jpg',
			'title'	=> 'nola sunglasses',
			'price' => '$350',
			),
		),
	2 => array(
		'full_image' => 'assets/images/products/f2.jpg',
		'top_left' => array(
			'image' => 'assets/images/products/13.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'top_right' => array(
			'image' => 'assets/images/products/14.jpg',
			'title'	=> 'Tote Handbag',
			'price' => '$350',
			),
		'bottom_left' => array(
			'image' => 'assets/images/products/15.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'bottom_right' => array(
			'image' => 'assets/images/products/16.jpg',
			'title'	=> 'nola sunglasses',
			'price' => '$350',
			),
		),
	3 => array(
		'full_image' => 'assets/images/products/f3.jpg',
		'top_left' => array(
			'image' => 'assets/images/products/17.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'top_right' => array(
			'image' => 'assets/images/products/18.jpg',
			'title'	=> 'Tote Handbag',
			'price' => '$350',
			),
		'bottom_left' => array(
			'image' => 'assets/images/products/19.jpg',
			'title'	=> 'white fashion dres',
			'price' => '$350',
			),
		'bottom_right' => array(
			'image' => 'assets/images/products/20.jpg',
			'title'	=> 'nola sunglasses',
			'price' => '$350',
			),
		),
	);
?>
<div class="row featured-content-holder">
	<div class="col-md-4 col-sm-12">
		<div class="featured-top-left">
			<?php foreach($sliders as $id => $slide): ?>
				<div class="featured-product text-center featured-image-<?php echo $id; ?>">
					<div class="image lazy-load">
						<a href="index.php?page=product-simple"><img class="img-responsive" src="assets/images/blank.gif" data-echo="<?php echo $slide['top_left']['image']; ?>" alt=""></a>
					</div><!-- .image -->
					<div class="product-body">
						<h3 class="product-title"><a href="index.php?page=product-simple"><?php echo $slide['top_left']['title']; ?></a></h3>
						<p class="product-amount"><?php echo $slide['top_left']['price']; ?></p>
					</div><!-- .content -->
				</div><!-- .featured-product -->
			<?php endforeach; ?>
		</div>
		<div class="featured-top-right">
			<?php foreach($sliders as $id => $slide): ?>
				<div class="featured-product text-center featured-image-<?php echo $id; ?>">
					<div class="image lazy-load">
						<a href="index.php?page=product-simple"><img class="img-responsive" src="assets/images/blank.gif" data-echo="<?php echo $slide['top_right']['image']; ?>" alt=""></a>
					</div><!-- .image -->
					<div class="product-body">
						<h3 class="product-title"><a href="index.php?page=product-simple"><?php echo $slide['top_right']['title']; ?></a></h3>
						<p class="product-amount"><?php echo $slide['top_right']['price']; ?></p>
					</div><!-- .content -->
				</div><!-- .featured-product -->
			<?php endforeach; ?>
		</div>
	</div><!-- .col -->

	<div class="col-md-4 col-sm-12">
		<div class="collection-style-holder thumbnail">
			<div class="featured-carousel-product">
				<?php foreach($sliders as $id => $slide): ?>
					<div class="item">
						<img src="assets/images/blank.gif" data-id="<?php echo $id; ?>" data-echo="<?php echo $slide['full_image']; ?>" alt="">
					</div>
				<?php endforeach; ?>
			</div><!-- .featured-carousel-product -->
			<div class="product-body text-center">
				<h2 class="exclusive-subtitle">spring 2015</h2>
				<h1 class="exclusive-title"><a href="index.php?page=product-simple">exclusive style</a></h1>
				<p class="info ">LOREM IPSUM DOLOR ETET USTED COLOREM IPSUM DOLOR UTET USTED LOREM UPSUM.</p>
				<button type="button" class="btn btn-default discover-look-button">Discover all looks</button>
			</div><!-- .content -->
		</div><!-- .featured-product -->
	</div>
	
	<div class="col-md-4 col-sm-12">
		<div class="featured-bottom-left">
			<?php foreach($sliders as $id => $slide): ?>
				<div class="featured-product text-center featured-image-<?php echo $id; ?>">
					<div class="image lazy-load">
						<a href="index.php?page=product-simple"><img class="img-responsive" src="assets/images/blank.gif" data-echo="<?php echo $slide['bottom_left']['image']; ?>" alt=""></a>
					</div><!-- .image -->
					<div class="product-body">
						<h3 class="product-title"><a href="index.php?page=product-simple"><?php echo $slide['bottom_left']['title']; ?></a></h3>
						<p class="product-amount"><?php echo $slide['bottom_left']['price']; ?></p>
					</div><!-- .content -->
				</div><!-- .featured-product -->
			<?php endforeach; ?>
		</div>
		<div class="featured-bottom-right">
			<?php foreach($sliders as $id => $slide): ?>
				<div class="featured-product text-center featured-image-<?php echo $id; ?>">
					<div class="image lazy-load">
						<a href="index.php?page=product-simple"><img class="img-responsive" src="assets/images/blank.gif" data-echo="<?php echo $slide['bottom_right']['image']; ?>" alt=""></a>
					</div><!-- .image -->
					<div class="product-body">
						<h3 class="product-title"><a href="index.php?page=product-simple"><?php echo $slide['bottom_right']['title']; ?></a></h3>
						<p class="product-amount"><?php echo $slide['bottom_right']['price']; ?></p>
					</div><!-- .content -->
				</div><!-- .featured-product -->
			<?php endforeach; ?>
		</div>
	</div>
</div>