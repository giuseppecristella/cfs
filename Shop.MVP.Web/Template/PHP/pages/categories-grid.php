<main>
	<section class="category-header">
		<header>
			<h1 class="category-title">Shop by Category</h1>
			<span class="category-subtitle">Pick up category you are interested in</span>
		</header>
	</section><!-- /.catalog-header -->
    
    <div class="category-content">
	   <div class="category-features">
		    <div class="container">
			    <div class="row">
				    <div class="col-md-3 col-sm-6">
					    <div class="text-center">
						    <div class="media feature">
							    <div class="media-left">
								    <i class="icon icon-30-days-return"></i>
							    </div>
							    <div class="media-body media-middle">
								    <h4 class="media-heading">30 days return</h4>
							    </div>
						    </div>
					    </div>
				    </div><!--col-->

				    <div class="col-md-6 hidden-sm">
					    <div class="text-center">
						    <div class="media feature">
							    <div class="media-left">
								    <i class="icon icon-truck"></i>
							    </div>
							    <div class="media-body media-middle">
								    <h4 class="media-heading">free shipping! on orders above $80</h4>
							    </div>
						    </div>
					    </div>
				    </div><!--col-->

				    <div class="col-md-3 col-sm-6">
					    <div class="text-center">
						    <div class="media feature">
							    <div class="media-left">
								    <i class="icon icon-secure-payment"></i>
							    </div>
							    <div class="media-body media-middle">
								    <h4 class="media-heading">secure payments</h4>
							    </div>
						    </div>
					    </div>
				    </div><!--col-->
			    </div><!--row-->
		    </div><!--container-->
	    </div><!--category-features-->

        <div class="category-grid-view">
		    <div class="container">
			    <div class="row">
			    	<?php
			    		$categories = array(
			    			array(
			    				'id'	=> 1,
			    				'name'	=> 'T-Shirts',
			    				'price'	=> '19',
		    				),
		    				array(
			    				'id'	=> 2,
			    				'name'	=> 'Jackets',
			    				'price'	=> '47',
		    				),
		    				array(
			    				'id'	=> 3,
			    				'name'	=> 'Hoodies',
			    				'price'	=> '69',
		    				),
		    				array(
			    				'id'	=> 4,
			    				'name'	=> 'Sweaters',
			    				'price'	=> '99',
		    				),
		    				array(
			    				'id'	=> 5,
			    				'name'	=> 'Denim Shorts',
			    				'price'	=> '15',
		    				),
		    				array(
			    				'id'	=> 6,
			    				'name'	=> 'Jeans',
			    				'price'	=> '38',
		    				),
		    				array(
			    				'id'	=> 7,
			    				'name'	=> 'Bags',
			    				'price'	=> '19',
		    				),
		    				array(
			    				'id'	=> 8,
			    				'name'	=> 'Shoes',
			    				'price'	=> '49',
		    				),
		    				array(
			    				'id'	=> 9,
			    				'name'	=> 'Accessories',
			    				'price'	=> '',
		    				),
		    			);
			    	foreach( $categories as $category ) : ?>
		    		<div class="col-md-6 col-sm-6 col-lg-4 wow fadeIn">
						<div class="category text-center">
							<div class="header">
								<h2 class="category-name"><a href="index.php?page=product-extended"><?php echo $category['name'];?></a></h2>
								<p class="starting-price">Start from <span>$<?php echo $category['price'];?></span></p>
							</div>
							<div class="section">
								<div class="image lazy-load">
									<a href="index.php?page=product-extended"><img src="assets/images/blank.gif" data-echo="assets/images/category/<?php echo $category['id'];?>.jpg" alt="<?php echo $category['name'];?>"></a>
								</div>
							</div>
							<div class="footer">
								<a href="index.php?page=product-extended" class="view-all">View all</a>
							</div>
						</div>
					</div>
		    		<?php endforeach; ?>		
			    </div><!--row-->
		    </div><!--container-->
	   </div><!--category-grid-view-->
    </div><!--category-content-->

	<?php require ROOT . '/parts/general/newsletter-block.php'; ?>
</main>


