	<div class="header text-center">
		<p class="odometer number-of-arrivals"></p>
		<h1 class="title">arrivals this month</h1>
	</div>
	<div class="section inner-top-50">
		<div class="row">
			<?php for ($i=0; $i <8 ; $i++): ?> 
			<div class="col-md-4 col-lg-3 col-sm-6">

				<div class="new-product">
					<?php 
					$arrivedProducts = array(1, 2, 3, 4,5,6,7,8);
					$arrivals = 'assets/images/arrived-products/'.$arrivedProducts[$i].'.jpg';
					?>
					<div class="image lazy-load">
						<a href="index.php?page=product-simple"><img class="img-responsive" src="assets/images/blank.gif" data-echo="<?php echo $arrivals;?>" alt=""></a>
					</div>
					<div class="product-body text-center">
						<h3 class="product-title"><a href="index.php?page=product-simple">Black Business Bag</a></h3>
						<p class="product-amount">$180</p>
					</div><!-- .content -->
				</div>
			</div>
		<?php endfor;?>	

	</div>
</div>