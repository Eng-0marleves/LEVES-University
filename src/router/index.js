import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import NotFoundView from '../views/NotFoundView.vue'
import Cookies from 'js-cookie';

const routes = [
  {
    path: '/home',
    name: 'Home',
    component: HomeView,
    meta: {
      requiresAuth: true
    },
  },
  {
    path: '/FAQs',
    name: 'FAQs',
    component: () => import('@/components/home/FAQs.vue'),
    meta: { requiresAuth: true },
  },
  {
    path: '/courses',
    name: 'Courses',
    component: () => import('../views/courses/CoursesView.vue'),
    meta: {
      requiresAuth: true,
      allowedRoles: ['doctor', 'student', 'admin']
    },
    children: [
      {
        path: '',
        name: 'Courses',
        component: () => import('../views/courses/CoursesHome.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code',
        name: 'Course',
        component: () => import('../views/courses/CourseHome.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseMaterials',
        name: 'CourseMaterials',
        component: () => import('../views/courses/CourseMaterial.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseAttendance',
        name: 'CourseAttendance',
        component: () => import('../views/courses/CourseAttendance.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseGrades',
        name: 'CourseGrades',
        component: () => import('../views/courses/CourseGrades.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseQuizzes',
        component: () => import('../views/courses/CourseQuizzes.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseQuizzes/quizzDetails/:quiz_id',
        component: () => import('@/components/courses/quizzes/QuizzDetails.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseQuizzes/:quiz_id',
        name: 'quizz',
        component: () => import('../views/courses/CourseQuiz.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseQuizzes/quizz_generator',
        component: () => import('../views/courses/QuizzGenerator.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseAssignments',
        component: () => import('../views/courses/assignments/AssignmentsHome.vue'),
        meta: { requiresAuth: true },
        children: [
          {
            path: '',
            name: 'Assignments',
            component: () => import('../views/courses/assignments/CourseAssignments.vue'),
            meta: {
              requiresAuth: true,
              allowedRoles: ['doctor', 'student', 'admin']
            }
          },
          // {
          //   path: 'assignmentDetails/:assignment_id',
          //   name: 'AssignmentDetails',
          //   component: () => import('../views/courses/assignments/AssignmentDetails.vue')
          // }
        ]
      },
      {
        path: ':course_code/CourseAssignments/generator',
        component: () => import('../views/courses/assignments/AssignmentGenerator.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
      {
        path: ':course_code/CourseSchedule',
        name: 'CourseSchedule',
        component: () => import('../views/courses/CourseSchedule.vue'),
        meta: {
          requiresAuth: true,
          allowedRoles: ['doctor', 'student', 'admin']
        }
      },
    ]
  },
  {
    path: '/dashboard/',
    component: () => import('../views/dashboard/DashboardHome.vue'),
    redirect: '/dashboard/profile',
    meta: { requiresAuth: true },
    children: [
      {
        path: '/dashboard/profile',
        component: () => import('../views/dashboard/DashboardProfile.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/time_table',
        component: () => import('../views/dashboard/DashboardTimeTable.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/register',
        component: () => import('../views/dashboard/DashboardRegister.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/financials',
        component: () => import('../views/dashboard/DashboardFinancials.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/report',
        component: () => import('../views/dashboard/DashboardReport.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/analysis',
        component: () => import('../views/dashboard/DashboardStudentAnalysis.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/students',
        component: () => import('../views/dashboard/students/StudentsPage.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/employees',
        component: () => import('../views/dashboard/employeers/EmployeesDashboard.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/books',
        component: () => import('../views/dashboard/LibraryDashboard.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/buildings',
        component: () => import('../views/dashboard/BuildingsDashboard.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/dashboard/semester',
        component: () => import('../views/dashboard/semester/semesterDashboard.vue'),
        meta: { requiresAuth: true }
      },
    ]
  },
  {
    path: '/schedule',
    component: () => import('../views/schedule/ScheduleView.vue'),
    redirect: '/schedule/scheduleHome',
    meta: { requiresAuth: true },
    children: [
      {
        path: '/schedule/scheduleHome',
        component: () => import('../views/schedule/ScheduleHome.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/schedule/schedules',
        component: () => import('../views/schedule/SchedulesPage.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/schedule/automation',
        component: () => import('../views/schedule/ScheduleHome.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/schedule/scheduling',
        component: () => import('../views/schedule/SchedulingPage.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/schedule/events',
        component: () => import('../views/schedule/ScheduleEvents.vue'),
        meta: { requiresAuth: true }
      }
    ]
  },
  {
    path: '/library',
    component: () => import('../views/library/LibraryHome.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/library/:bookId',
    props: true,
    component: () => import('../views/library/BookPage.vue'),
    meta: { requiresAuth: true }
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
    meta: { requiresAuth: true }
  },
  {
    path: '/articals',
    component: () => import('../views/articals/ArticalsHone.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/articals/:id',
    props: true,
    component: () => import('../views/articals/ArticleDetail.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/support',
    component: () => import('../views/support/SupportChat.vue'),
    redirect: '/Support/inpox',
    children: [
      {
        path: '/Support/inpox',
        component: () => import('../views/support/ChatInbox.vue'),
        meta: { requiresAuth: true }
      },
      {
        path: '/Support/chat',
        component: () => import('../views/support/ChatApp.vue'),
        meta: { requiresAuth: true }
      },
    ]
  },
  {
    path: '/login',
    name: 'Login',
    component: LoginView,
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
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = Cookies.get('user-auth-token');
  const userRole = Cookies.get('user-role');

  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!isAuthenticated) {
      next({ name: 'Login' });
    } else {
      if (checkAuthorization(userRole, to.meta.allowedRoles)) {
        next();
      } else {
        next({ name: 'NotFound' });
      }
    }
  } else if (to.name === 'Login' && isAuthenticated) {
    next({ name: 'Home' });
  } else {
    next();
  }
});

function checkAuthorization(userRole, allowedRoles) {
  if (!allowedRoles) {
    return true;
  }
  return allowedRoles.includes(userRole);
}

export default router;
