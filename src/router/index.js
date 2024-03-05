import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import NotFoundView from '../views/NotFoundView.vue'

const routes = [
  {
    path: '/home',
    name: 'Home',
    component: HomeView,
    meta: { requiresAuth: true }
  },
  {
    path: '/courses',
    name: 'Courses',
    component: () => import('../views/courses/CoursesView.vue'),
    meta: { requiresAuth: true },
    children: [
      {
        path: '',
        name: 'CoursesHome',
        component: () => import('../views/courses/CoursesHome.vue')
      },
      {
        path: ':course_code',
        name: 'Course',
        component: () => import('../views/courses/CourseHome.vue'),
        children: [
          {
            path: 'CourseMaterials',
            name: 'CourseMaterials',
            component: () => import('../views/courses/CourseMaterial.vue')
          },
          // {
          //   path: 'CourseAttendance',
          //   name: 'CourseAttendance',
          //   component: () => import('../views/courses/CourseAttendance.vue')
          // },
          // {
          //   path: 'CourseGrades',
          //   name: 'CourseGrades',
          //   component: () => import('../views/courses/CourseGrades.vue')
          // },
          // {
          //   path: 'CourseQuizzes',
          //   name: 'CourseQuizzes',
          //   component: () => import('../views/courses/CourseQuizzes.vue')
          // },
          // {
          //   path: 'CourseAssigments',
          //   name: 'CourseAssigments',
          //   component: () => import('../views/courses/CourseAssigments.vue')
          // },
          // {
          //   path: 'CourseSchedule',
          //   name: 'CourseSchedule',
          //   component: () => import('../views/courses/CourseSchedule.vue')
          // },
        ]
      }
    ]
  },
  {
    path: '/login',
    name: 'Login',
    component: LoginView
  },
  {
    path: '/:pathMatch(.*)*',
    name: 'NotFound',
    component: NotFoundView,
    meta: { requiresAuth: true }
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from, next) => {
  const isAuthenticated = !!localStorage.getItem('user-info')

  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!isAuthenticated) {
      next({ name: 'Login' })
    } else {
      next()
    }
  } else if (to.name === 'Login' && isAuthenticated) {
    next({ name: 'Home' })
  } else {
    next()
  }
})

export default router
