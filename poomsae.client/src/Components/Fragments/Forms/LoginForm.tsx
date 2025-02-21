import { useState } from "react"
import { Form } from "antd"
import { useNavigate } from "react-router-dom"
import Link from "antd/es/typography/Link"
import useUserService from "../../../Hooks/Services/UseUserService"
import SubmitButton from "../../Molecules/SubmitButton"
import useLocalStorage from "../../../Hooks/useLocalStorage"
import EmailFormItem from "./FormInputs/EmailFormItem"
import PasswordFormItem from "./FormInputs/PasswordFormItem"
import AuthentificationForm from "./Generics/AuthentificationForm"

type LoginFormInputs = {
    email: string
    password: string
    confirmPassword: string
}

const LoginForm: React.FC = () => {
    const localStorage = useLocalStorage()
    const [form] = Form.useForm<LoginFormInputs>()
    const [loading, setLoading] = useState<boolean>(false)
    const userRepository = useUserService()
    const navigate = useNavigate()

    if (localStorage.GetUser() != null && localStorage.GetUser().isAuthenticated)
        navigate("/hub")

    const onFinish = async (e: LoginFormInputs) => {
        console.log(e)
        setLoading(true)
        await userRepository.login({ email: e.email, password: e.password })
        setLoading(false)
    }

    return (
        <AuthentificationForm
            form={form}
            onFinish={onFinish}>
            <EmailFormItem />
            <PasswordFormItem />
            <SubmitButton style={{ background: "linear-gradient(90deg, #c60c30, #003478)" }} loading={loading} text="Login" />
            <Link style={{ fontWeight: "bold" }} onClick={() => navigate("/create_account")}>Not a member ?</Link>
        </AuthentificationForm>
    )
}

export default LoginForm