import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { MatTabsModule } from "@angular/material/tabs";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { PdfViewerModule } from "ng2-pdf-viewer";

import { AppRoutingModule } from "./app.routing";
import { AppComponent } from "./app.component";
import { AuthGuard } from "./auth/auth.guard";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { Routes, RouterModule } from "@angular/router";
import { OwlDateTimeModule, OwlNativeDateTimeModule } from "ng-pick-datetime";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatListModule } from "@angular/material/list";
import { MatProgressBarModule } from "@angular/material/progress-bar";

import { MatSortModule } from "@angular/material/sort";
import { YouTubePlayerModule } from "@angular/youtube-player";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { OrderModule } from "ngx-order-pipe";
import { AgmCoreModule } from "@agm/core";
import { PassQuizComponent } from "./pass-quiz/pass-quiz.component";
import { UserService } from "./user-profile/user.service";
import { from } from "rxjs";
import { AuthInterceptor } from "./auth/auth.interceptor";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { NgxPaginationModule } from "ngx-pagination";
import { MatDialogModule } from "@angular/material/dialog";
import { MatSelectModule } from "@angular/material/select";
import { MatNativeDateModule } from "@angular/material/core";
import { SuccessDialogComponent } from "./shared/dialogs/success-dialog/success-dialog.component";
import { ErrorDialogComponent } from "./shared/dialogs/error-dialog/error-dialog.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { MatTooltipModule } from "@angular/material/tooltip";
import { CommonService } from "./shared/services/common.service";
import { CourseQuizzesComponent } from "./course-quizzes/course-quizzes.component";

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    NgxPaginationModule,
    FormsModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    HttpModule,
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    AgmCoreModule.forRoot({}),
    OrderModule,
    MatTabsModule,
    MatExpansionModule,
    PdfViewerModule,
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    NgxPaginationModule,
    ReactiveFormsModule,
    MatSortModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatListModule,
    MatToolbarModule,
    HttpClientModule,
    FormsModule,
    MatCheckboxModule,
    MatIconModule,
    ReactiveFormsModule,
    HttpModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    AppRoutingModule,
    MatNativeDateModule,
    MatSelectModule,
    MatDialogModule,
    AppRoutingModule,
    YouTubePlayerModule,
    PdfViewerModule,
    MatProgressBarModule,
    NgbModule,
    MatTooltipModule,
  ],
  exports: [CommonModule],
  declarations: [
    AppComponent,
    PassQuizComponent,
    ErrorDialogComponent,
    //UserProfileComponent,
    //UserProfileComponent,
    CourseQuizzesComponent,
  ],
  providers: [CommonService],
  bootstrap: [AppComponent],
})
export class AppModule {}
