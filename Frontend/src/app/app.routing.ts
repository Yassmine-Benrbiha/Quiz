import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";
import { PassQuizComponent } from "./pass-quiz/pass-quiz.component";
import { AuthGuard } from "./auth/auth.guard";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { CourseQuizzesComponent } from "./course-quizzes/course-quizzes.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "quizzes",
    pathMatch: "full",
  },
  {
    path: "quizzes",
    component: CourseQuizzesComponent,
  },
  {
    path: "pass-quiz/:QuizID",
    component: PassQuizComponent,
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
    }),
  ],
  exports: [],
})
export class AppRoutingModule {}
