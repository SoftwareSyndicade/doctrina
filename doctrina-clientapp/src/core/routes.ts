import AccountRegistrationPage from '../components/AccountRegistrationPage/AccountRegistrationPage';
import AssistanceRequestPage from '../components/AssistanceRequestPage/AssistanceRequestPage';
import HomePage from '../components/HomePage/HomePage';
import LoginPage from "../components/LoginPage/LoginPage";
import IRoute from "./IRoute";

const ROUTES: IRoute[] = [
    {
        path: '/',
        name: "",
        component: LoginPage,
        exact: true
    },{
        path: '/register',
        name: "",
        component: AccountRegistrationPage,
        exact: true
    }, {
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
    }
]

export default ROUTES