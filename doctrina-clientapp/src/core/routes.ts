import AccountRegistrationPage from '../components/AccountRegistrationPage/AccountRegistrationPage';
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
    }
]

export default ROUTES