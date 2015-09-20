<div class="container inner-top-sm">
	<div role="tabpanel">
		<div class="tab-nav-holder single-product-tab inner-bottom-50">
			<ul id="single-product-tabs" class="nav nav-tabs uppercase" role="tablist">
				<li role="presentation" ><a href="#wear-with" data-transition-type="backSlide" role="tab" data-toggle="tab">wear with it</a></li>
				<li role="presentation" class="active"><a href="#related-products" data-transition-type="backSlide" role="tab" data-toggle="tab">related products</a></li>
			</ul>
		</div>
		<div class="tab-content">
			<div role="tabpanel" class="tab-pane" id="wear-with">
				<div class="single-product-wear-it wow fadeInUp">
					<?php include ROOT.'/parts/products/wear-product-carousel-item.php'; ?>
				</div>
			</div><!-- /.tab-pane -->
			<div role="tabpanel" class="tab-pane active" id="related-products">
				<div class="single-product-related-products wow fadeInUp">
					<?php include ROOT.'/parts/products/related-product-carousel-item.php'; ?>
				</div>
			</div><!-- /.tab-pane -->
		</div><!-- /.tab-content -->
	</div><!-- /.tabpanel -->
</div><!-- /.containers -->