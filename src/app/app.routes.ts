import { Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';

export const routes: Routes = [
	{ path: "", redirectTo: 'login', pathMatch: "full" },
	{ path: "login", component: LoginPageComponent },
	{ path: "home", component: HomePageComponent },
	{ path: "**", component: NotFoundPageComponent }
];
