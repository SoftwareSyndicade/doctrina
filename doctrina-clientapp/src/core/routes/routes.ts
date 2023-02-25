import AccountRegistrationPage from '../../components/AccountRegistrationPage/AccountRegistrationPage';
import AssistanceProposal from '../../components/AssistanceProposal/AssistanceProposal';
import AssistanceRequestPage from '../../components/AssistanceRequestPage/AssistanceRequestPage';
import HomePage from '../../components/HomePage/HomePage';
import LoginPage from "../../components/LoginPage/LoginPage";
import IRoute from "./IRoute";

export const OPEN_ROUTES: IRoute[] = [
    {
        path: '/',
        name: "",
        component: LoginPage,
        exact: true
    }, {
        path: '/register',
        name: "",
        component: AccountRegistrationPage,
        exact: true
    }
]

export const PROTECTED_ROUTES: IRoute[] = [
    {
        path: '/home',
        name: "",
        component: HomePage,
        exact: true
    },
    {
        path: '/assistance-request',
        name: "",
        component: AssistanceRequestPage,
        exact: true
    },
    {
        path: '/assistance-proposal',
        name: "",
        component: AssistanceProposal,
        exact: true
    }
]