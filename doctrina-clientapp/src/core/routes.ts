import AccountRegistrationPage from '../components/AccountRegistrationPage/AccountRegistrationPage';
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
    }
]

export default ROUTES