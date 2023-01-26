import LoginPage from "../components/LoginPage/LoginPage";
import IRoute from "./IRoute";

const ROUTES: IRoute[] = [
    {
        path: '/',
        name: "",
        component: LoginPage,
        exact: true
    }
]

export default ROUTES