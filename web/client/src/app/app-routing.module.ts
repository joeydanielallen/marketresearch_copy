import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserService } from './shared/services/user.service';
import { LoggerService } from './shared/services/logger.service';
import { LoginComponent } from './shared/components/login/login.component';


const routes: Routes = [
  { path: '', loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule) },
  { path: 'login', component: LoginComponent },
  { path: 'search', loadChildren: () => import('./search/search.module').then(m => m.SearchModule) },
  { path: 'dashboard', loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule) },
  { path: 'bookmark', loadChildren: () => import('./bookmark/bookmark.module').then(m => m.BookmarkModule) },
  { path: 'library', loadChildren: () => import('./library/library.module').then(m => m.LibraryModule) },
  { path: 'message', loadChildren: () => import('./message/message.module').then(m => m.MessageModule) },
  { path: 'analytics', loadChildren: () => import('./analytics/analytics.module').then(m => m.AnalyticsModule) },
  { path: 'research', loadChildren: () => import('./research/research.module').then(m => m.ResearchModule) },
  { path: 'profile', loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule) },
  { path: 'vendor', loadChildren: () => import('./vendor/vendor.module').then(m => m.VendorModule) },
  { path: 'notes', loadChildren: () => import('./notes/notes.module').then(m => m.NotesModule) }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  providers: [
    UserService,
    LoggerService
  ]
})
export class AppRoutingModule { }
