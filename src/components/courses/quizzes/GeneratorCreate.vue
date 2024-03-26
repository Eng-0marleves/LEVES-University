<template>
	<div class="create pb-3">
		<div class="pages" ref="pagesContainer"> <!-- Add ref attribute to the container div -->
			<GeneratorPage :draggable="isDraggable" v-for="(page, index) in pages" :key="index" :page="page"
				:pageNumber="index + 1" @delete-page="deletePage(index)" @edit-page="editPage"
				@move-page="movePage($event)" @save-page="handleSavePage" />
		</div>
		<button class="btn normal" @click="addPage">Add Page</button>
	</div>
</template>

<script>
import GeneratorPage from '@/components/courses/quizzes/GeneratorPage.vue';

export default {
	name: 'GeneratorCreate',
	data() {
		return {
			nextPageNumber: 2,
			pages: [
				{
					pageId: this.generateUniqueId(8),
					title: `Page 1`,
					questions: []
				}
			],
			isDraggable: false
		};
	},
	components: {
		GeneratorPage
	},
	methods: {
		generatePageId() {
			const timestamp = Date.now().toString(36); // Convert timestamp to base 36 string
			const randomSuffix = Math.random().toString(36).substring(2, 8); // Generate a random string
			return `${timestamp}-${randomSuffix}`;
		},
		addPage() {
			this.pages.push({
				pageId: this.generateUniqueId(8),
				title: `Page ${this.nextPageNumber}`,
				questions: []
			});
			this.nextPageNumber++;
		},
		generateUniqueId(length) {
			let result = '';
			const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
			const charactersLength = characters.length;
			for (let i = 0; i < length; i++) {
				result += characters.charAt(Math.floor(Math.random() * charactersLength));
			}
			return result;
		},
		deletePage(index) {
			this.pages.splice(index, 1);
			this.nextPageNumber--;
		},
		editPage(pageId, newTitle) {
			const pageIndex = this.pages.findIndex(page => page.pageId === pageId);
			if (pageIndex !== -1) {
				this.pages[pageIndex].title = newTitle;
			}
		},
		movePage() {
			this.isDraggable = true;
			const pagesList = this.$refs.pagesContainer; // Use $refs to select the container div
			const pages = document.querySelectorAll('.page');

			pages.forEach(el => {
				el.addEventListener("dragstart", () => {
					el.classList.add("dragging")
				});

				el.addEventListener("dragend", () => el.classList.remove("dragging"))
			});

			const sortedPages = (e) => {
				e.preventDefault(); // Add preventDefault here if necessary
				const dragEl = document.querySelector('.dragging');
				const otherPages = [...pages].filter(page => page !== dragEl);

				let nextPage = otherPages.find(el => {
					return e.clientY < el.getBoundingClientRect().top + el.getBoundingClientRect().height / 2;
				});

				pagesList.insertBefore(dragEl, nextPage);
				this.isDraggable = false;
			}

			pagesList.addEventListener("dragover", (e) => sortedPages(e));
		},
		handleSavePage(pageData) {
			// this.pages.forEach(e => {
			// 	// if (e.pageId === pageData.pageId) {
			// 	// 	for (let i of pageData.questions) {
			// 	// 		e.questions.push(i)
			// 	// 	}
			// 	// }

			// 	e
			// })

			console.log(this.pages);
			console.log(pageData);
		},
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
.pages {
	width: 100%;
	padding: 16px;
	display: flex;
	justify-content: center;
	align-items: center;
	flex-direction: column;
	gap: 32px;
}

.create {
	width: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
	flex-direction: column;
	gap: 16px;
}
</style>
