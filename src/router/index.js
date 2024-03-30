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
    path: '/FAQs',
    name: 'FAQs',
    component: () => import('@/components/home/FAQs.vue'),
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
        name: 'Courses',
        component: () => import('../views/courses/CoursesHome.vue'),
      },
      {
        path: ':course_code',
        name: 'Course',
        component: () => import('../views/courses/CourseHome.vue'),
      },
      {
        path: ':course_code/CourseMaterials',
        name: 'CourseMaterials',
        component: () => import('../views/courses/CourseMaterial.vue')
      },
      {
        path: ':course_code/CourseAttendance',
        name: 'CourseAttendance',
        component: () => import('../views/courses/CourseAttendance.vue')
      },
      {
        path: ':course_code/CourseGrades',
        name: 'CourseGrades',
        component: () => import('../views/courses/CourseGrades.vue')
      },
      {
        path: ':course_code/CourseQuizzes',
        component: () => import('../views/courses/CourseQuizzes.vue'),
      },
      {
        path: ':course_code/CourseQuizzes/quizzDetails/:quiz_id',
        component: () => import('@/components/courses/quizzes/QuizzDetails.vue')
      },
      {
        path: ':course_code/CourseQuizzes/:quiz_id',
        name: 'quizz',
        component: () => import('../views/courses/CourseQuiz.vue')
      },
      {
        path: ':course_code/CourseQuizzes/quizz_generator',
        component: () => import('../views/courses/QuizzGenerator.vue')
      },
      {
        path: ':course_code/CourseAssignments',
        component: () => import('../views/courses/assignments/AssignmentsHome.vue'),
        children: [
          {
            path: '',
            name: 'Assignments',
            component: () => import('../views/courses/assignments/CourseAssignments.vue')
          },
          // {
          //   path: 'assignmentDetails/:assignment_id',
          //   name: 'AssignmentDetails',
          //   component: () => import('../views/courses/assignments/AssignmentDetails.vue')
          // }
        ]
      },
      {
        path: ':course_code/CourseSchedule',
        name: 'CourseSchedule',
        component: () => import('../views/courses/CourseSchedule.vue')
      },
    ]
  },
  {
    path: '/dashboard/',
    component: () => import('../views/dashboard/DashboardHome.vue'),
    redirect: '/dashboard/profile',
    children: [
      {
        path: '/dashboard/profile',
        component: () => import('../views/dashboard/DashboardProfile.vue'),
      },
      {
        path: '/dashboard/time_table',
        component: () => import('../views/dashboard/DashboardTimeTable.vue'),
      },
      {
        path: '/dashboard/register',
        component: () => import('../views/dashboard/DashboardRegister.vue'),
      },
      {
        path: '/dashboard/financials',
        component: () => import('../views/dashboard/DashboardFinancials.vue'),
      },
      {
        path: '/dashboard/report',
        component: () => import('../views/dashboard/DashboardReport.vue'),
      },
      {
        path: '/dashboard/analysis',
        component: () => import('../views/dashboard/DashboardStudentAnalysis.vue'),
      },
    ]
  },
  {
    path: '/schedule',
    component: () => import('../views/schedule/ScheduleView.vue'),
    redirect: '/schedule/scheduleHome',
    children: [
      {
        path: '/schedule/scheduleHome',
        component: () => import('../views/schedule/ScheduleHome.vue'),
      },
      {
        path: '/schedule/schedules',
        component: () => import('../views/schedule/SchedulesPage.vue'),
      },
      {
        path: '/schedule/automation',
        component: () => import('../views/schedule/ScheduleHome.vue'),
      },
      {
        path: '/schedule/scheduling',
        component: () => import('../views/schedule/SchedulingPage.vue'),
      },
      {
        path: '/schedule/events',
        component: () => import('../views/schedule/ScheduleEvents.vue'),
      }
    ]
  },
  {
    path: '/library',
    component: () => import('../views/library/LibraryHome.vue'),
  },
  {
    path: '/library/:bookId',
    props: true,
    component: () => import('../views/library/BookPage.vue'),
  },
  {
    path: '/news',
    name: 'news',
    component: () => import('../views/NewsPage.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/announcements/:announcementId',
    props: true,
    component: () => import('../components/news/AnnouncementPage.vue'),
  },
  {
    path: '/articals',
    component: () => import('../views/articals/ArticalsHone.vue'),
  },
  {
    path: '/articals/:id',
    props: true,
    component: () => import('../views/articals/ArticleDetail.vue'),
  },
  {
    path: '/support',
    component: () => import('../views/support/SupportChat.vue'),
    redirect: '/Support/inpox',
    children: [
      {
        path: '/Support/inpox',
        component: () => import('../views/support/ChatInbox.vue'),
      },
      {
        path: '/Support/chat',
        component: () => import('../views/support/ChatApp.vue'),
      },
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
  const isAuthenticated = !!localStorage.getItem('auth-token')

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
