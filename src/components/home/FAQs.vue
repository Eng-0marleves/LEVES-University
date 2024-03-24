<template>
	<div class="faqs d-flex flex-column gap-4 align-center">
		<div class="title text-center d-flex flex-column gap-2 align-center">
			<h1>FAQs</h1>
			<p>
				Welcome to our FAQ section! Here, you'll find answers to common questions about our services, products,
				and policies. Feel free to explore and discover valuable information to enhance your experience with us.
			</p>
		</div>

		<div class="controllers d-flex justify-content-between align-center w-100">
			<button type="button" class="btn normal" data-bs-toggle="modal" data-bs-target="#staticBackdrop">Add
				Item</button>


			<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
				aria-labelledby="staticBackdropLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<h1 class="modal-title fs-5" id="staticBackdropLabel">New Q&A</h1>
							<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
						</div>
						<div class="modal-body">
							<form>
								<div class="mb-3">
									<label for="header" class="form-label">Question</label>
									<input type="text" v-model="header" class="form-control" id="header"
										placeholder="Enter the question">
								</div>
								<div class="mb-3">
									<label for="body" class="form-label">Andswer</label>
									<textarea v-model="content" class="form-control" id="content" rows="3"
										placeholder="Enter the Answer"></textarea>
								</div>
							</form>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancle</button>
							<button type="button" class="btn btn-success" @click="save">Save</button>
						</div>
					</div>
				</div>
			</div>


			<SearchBar @search="handleSearch" />
		</div>

		<QA_Item class="items" :items="filteredItems" :all="true" />
	</div>
</template>

<script>
import QA_Item from '@/components/home/QA_Item.vue';
import SearchBar from '../global/SearchBar.vue';
import axios from 'axios';

export default {
	name: 'FAQs',
	components: {
		QA_Item,
		SearchBar
	},
	data() {
		return {
			accordionItems: [],
			searchQuery: '',
			header: '',
			content: ''
		};
	},
	computed: {
		filteredItems() {
			if (!this.searchQuery.trim()) {
				return this.accordionItems;
			}
			return this.accordionItems.filter(item => {
				// You can customize the search logic based on your requirements
				return item.header.toLowerCase().includes(this.searchQuery.toLowerCase());
			});
		}
	},
	methods: {
		handleSearch(query) {
			this.searchQuery = query;
		},
		async save() {
			const newItem = {
				header: this.header,
				content: this.content
			};

			const res = await axios.post('http://localhost:5062/api/FAQs', newItem);
			if (res.status == 201) {
				this.accordionItems.push(res.data);
				this.header = '';
				this.content = '';
				document.querySelector('.modal').classList.remove('show');
				document.querySelector('.modal-backdrop').remove();
			}
		}
	},
	async created() {
		console.log('Getting FAQs');
		const res = await axios.get('http://localhost:5062/api/FAQs');
		if (res.status == 200) {
			this.accordionItems = res.data;
		}
	}
};
</script>

<style scoped>
.faqs {
	padding: 16px;
}

.accordion-btn {
	width: 100% !important;
}
</style>
