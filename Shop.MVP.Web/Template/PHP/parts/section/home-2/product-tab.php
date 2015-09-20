<?php 
$products = array(
	array(
		'image' => '5.jpg',
		'name'	=> 'Rotterdam Tshirt',
		'price'	=> '$19',
		'radio' => array( 'gray', 'brown' )
	),
	array(
		'image' => '6.jpg',
		'name'	=> 'White Fashion Dress',
		'price'	=> '$47',
		'radio' => array( 'yellow', 'violet', 'orange' )
	),
	array(
		'image' => '7.jpg',
		'name'	=> 'Flocked Print Sweatshirt',
		'price'	=> '$140',
		'radio' => array( 'brown', 'dark-gray' )
	),
	array(
		'image' => '8.jpg',
		'name'	=> 'White Fashion Dress',
		'price'	=> '$90',
		'radio' => array( 'violet', 'gray', 'red', 'green' )
	),
	array(
		'image' => '9.jpg',
		'name'	=> 'Slim Short Pants',
		'price'	=> '$119',
		'radio' => array( 'black', 'brown' )
	),
	array(
		'image' => '10.jpg',
		'name'	=> 'South Beach Vest',
		'price'	=> '$57',
		'radio' => array( 'blue', 'orange' )
	),
	array(
		'image' => '11.jpg',
		'name'	=> 'Denim Trim Backpack',
		'price'	=> '$99',
		'radio' => array( 'blue', 'black' )
	),
	array(
		'image' => '12.jpg',
		'name'	=> 'Contrast Shoulder Path',
		'price'	=> '$110',
		'radio' => array( 'black', 'gray', 'brown' )
	),
);
?>
<div class="product-tab-ver2">
		<div role="tabpanel">
		  <!-- Nav tabs -->
		    <div class="tab-nav-holder">
			    <ul class="nav nav-tabs uppercase" role="tablist">
			        <li role="presentation" class="active"><a href="#just-arrived" aria-controls="just-arrived" role="tab" data-toggle="tab">just arrived</a></li>
			        <li role="presentation"><a href="#best-seller" aria-controls="best-seller" role="tab" data-toggle="tab">best sellers</a></li>
			        <li role="presentation"><a href="#hot-products" aria-controls="hot-products" role="tab" data-toggle="tab">hot products</a></li>
			    </ul><!--nav-tabs-->
		    </div><!--tab-nav-holder-->

		    <!-- Tab panes -->
		    <div class="tab-content inner-top-xs">
			    <div role="tabpanel" class="tab-pane active" id="just-arrived">
			    	<div class="row grid-view">
			    		<?php shuffle( $products ); ?>
			    		<?php foreach ( $products as $key => $product ) : ?>
		    			<div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
							<div class="product">
								<div class="image">
									<a href="index.php?page=product-simple"><img class="img-responsive" width="258" src="assets/images/blank.gif" data-echo="assets/images/products/<?php echo $product['image'];?>"  alt=""></a>
								</div><!-- .image -->
								<div class="product-info m-t-20 text-center">
									<a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i> Quick view</a>
									<ul class="color-picker clearfix">
										<?php foreach( $product['radio'] as $rKey => $radio ) : ?>
											<li <?php if ($rKey == 0 ) { echo 'class="selected"'; }?>><input <?php if ($rKey == 0 ) { echo 'checked="checked"'; }?> class="le-radio group <?php echo $radio;?>" type="radio" value="g1-<?php echo $rKey;?>" name="rgroup-<?php echo $key;?>"></li>
										<?php endforeach; ?>
									</ul><!-- .color-picker -->
									<h5 class="name uppercase"><a href="index.php?page=product-simple"><?php echo $product['name'];?></a></h5>
									<div class="product-price">
										<ins><span class="amount"><?php echo $product['price'];?></span></ins>
									</div><!-- .product-price -->
									<div class="buttons-holder m-t-20">					
										<div class="add-cart-holder">
											<a title="Add to cart" href="index.php?page=checkout" class="cart-button btn btn-primary">
												<span>Add to bag</span>
											</a>
										</div><!-- .add-cart-holder -->
										<div class="add-wishlist-holder">
											<a href="index.php?page=checkout" title="Wishlist" class="wishlist-button uppercase">
												<span class="icon icon-wishlist"></span> add to wishlist
											</a>
										</div><!-- .add-wishlist-holder -->
									</div><!-- .buttons-holder -->
								</div><!-- .product-info -->
							</div>
						</div>
		    			<?php endforeach; ?>
			    	</div><!-- .row -->			    	
			    </div><!-- .tab-pane -->

			    <div role="tabpanel" class="tab-pane fade" id="best-seller">
			    	<div class="row grid-view">	
			    		<?php shuffle( $products ); ?>
	                	<?php foreach ( $products as $key => $product ) : ?>
		    			<div class="col-md-4 col-sm-6  col-lg-3 col-xs-12 product-holder">
							<div class="product">
								<div class="image">
									<a href="index.php?page=product-simple"><img class="img-responsive" width="258" src="assets/images/blank.gif" data-echo="assets/images/products/<?php echo $product['image'];?>"  alt=""></a>
								</div><!-- .image -->
								<div class="product-info m-t-20 text-center">
									<a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i> Quick view</a>
									<ul class="color-picker clearfix">
										<?php foreach( $product['radio'] as $rKey => $radio ) : ?>
											<li <?php if ($rKey == 0 ) { echo 'class="selected"'; }?>><input <?php if ($rKey == 0 ) { echo 'checked="checked"'; }?> class="le-radio group <?php echo $radio;?>" type="radio" value="g1-<?php echo $rKey;?>" name="rgroup-<?php echo $key;?>"></li>
										<?php endforeach; ?>
									</ul><!-- .color-picker -->
									<h5 class="name uppercase"><a href="index.php?page=product-simple"><?php echo $product['name'];?></a></h5>
									<div class="product-price">
										<ins><span class="amount"><?php echo $product['price'];?></span></ins>
									</div><!-- .product-price -->
									<div class="buttons-holder m-t-20">					
										<div class="add-cart-holder">
											<a title="Add to cart" href="index.php?page=checkout" class="cart-button btn btn-primary">
												<span>Add to bag</span>
											</a>
										</div><!-- .add-cart-holder -->
										<div class="add-wishlist-holder">
											<a href="index.php?page=checkout" title="Wishlist" class="wishlist-button uppercase">
												<span class="icon icon-wishlist"></span> add to wishlist
											</a>
										</div><!-- .add-wishlist-holder -->
									</div><!-- .buttons-holder -->
								</div><!-- .product-info -->
							</div>
						</div>
		    			<?php endforeach; ?>
			    	</div><!-- .row -->			    	
			    </div><!--tab-pane-->

			    <div role="tabpanel" class="tab-pane fade" id="hot-products">
			    	<div class="row grid-view">
			    		<?php shuffle( $products ); ?>	    		
	                	<?php foreach ( $products as $key => $product ) : ?>
		    			<div class="col-md-4 col-sm-6  col-lg-3 col-xs-12 product-holder">
							<div class="product">
								<div class="image">
									<a href="index.php?page=product-simple"><img class="img-responsive" width="258" src="assets/images/blank.gif" data-echo="assets/images/products/<?php echo $product['image'];?>"  alt=""></a>
								</div><!-- .image -->
								<div class="product-info m-t-20 text-center">
									<a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i> Quick view</a>
									<ul class="color-picker clearfix">
										<?php foreach( $product['radio'] as $rKey => $radio ) : ?>
											<li <?php if ($rKey == 0 ) { echo 'class="selected"'; }?>><input <?php if ($rKey == 0 ) { echo 'checked="checked"'; }?> class="le-radio group <?php echo $radio;?>" type="radio" value="g1-<?php echo $rKey;?>" name="rgroup-<?php echo $key;?>"></li>
										<?php endforeach; ?>
									</ul><!-- .color-picker -->
									<h5 class="name uppercase"><a href="index.php?page=product-simple"><?php echo $product['name'];?></a></h5>
									<div class="product-price">
										<ins><span class="amount"><?php echo $product['price'];?></span></ins>
									</div><!-- .product-price -->
									<div class="buttons-holder m-t-20">					
										<div class="add-cart-holder">
											<a title="Add to cart" href="index.php?page=checkout" class="cart-button btn btn-primary">
												<span>Add to bag</span>
											</a>
										</div><!-- .add-cart-holder -->
										<div class="add-wishlist-holder">
											<a href="index.php?page=checkout" title="Wishlist" class="wishlist-button uppercase">
												<span class="icon icon-wishlist"></span> add to wishlist
											</a>
										</div><!-- .add-wishlist-holder -->
									</div><!-- .buttons-holder -->
								</div><!-- .product-info -->
							</div>
						</div>
		    			<?php endforeach; ?>
			    	</div><!-- .row -->			    	
			    </div><!--tab-pane-->		    
		    </div><!--tab-content-->
		</div><!--tabpanel-->		
	</div><!--product-tab-ver2-->