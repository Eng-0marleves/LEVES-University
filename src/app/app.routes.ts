import { Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { CoursesComponent } from './pages/courses/courses.component';
import { CourseComponent } from './pages/course/course.component';
import { CoursesListComponent } from './pages/courses-list/courses-list.component';
import { PostComponent } from './components/post/post.component';
import { MaterialsComponent } from './components/materials/materials.component';
import { QuizzesComponent } from './components/quizzes/quizzes.component';
import { AssignmentsComponent } from './components/assignments/assignments.component';
import { GradesComponent } from './components/grades/grades.component';
import { AttendanceComponent } from './components/attendance/attendance.component';
import { VisitsComponent } from './components/visits/visits.component';
import { HomeComponent } from './components/quizzes/home/home.component';
import { GenerateQuizzComponent } from './components/quizzes/generate-quizz/generate-quizz.component';

export const routes: Routes = [
	{ path: "", redirectTo: 'login', pathMatch: "full" },
	{ path: "login", component: LoginPageComponent },
	{ path: "home", component: HomePageComponent },
	{
		path: "courses", component: CoursesComponent,
		children: [
			{ path: "", component: CoursesListComponent },
			{ path: "course", component: CourseComponent,
				children: [
					{path: "", component: PostComponent},
					{path: "materials", component: MaterialsComponent},
					{path: "quizzes", component: QuizzesComponent, children: [
						{path: "", component: HomeComponent},
						{path: "generate", component: GenerateQuizzComponent},
					]},
					{path: "assignments", component: AssignmentsComponent},
					{path: "grades", component: GradesComponent},
					{path: "attendance", component: AttendanceComponent},
					{path: "visits", component: VisitsComponent},
				]
			}
		]
	},
	{ path: "**", component: NotFoundPageComponent }
];
