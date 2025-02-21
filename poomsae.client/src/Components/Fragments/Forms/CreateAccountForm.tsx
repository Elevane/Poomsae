import { Form } from "antd"
import Link from "antd/es/typography/Link"
import { useState } from "react"
import useUserService from "../../../Hooks/Services/UseUserService"
import { useNavigate } from "react-router"
import SubmitButton from "../../Molecules/SubmitButton"
import EmailFormItem from "./FormInputs/EmailFormItem"
import PasswordFormItem from "./FormInputs/PasswordFormItem"
import ConfirmPasswordFormItem from "./FormInputs/ConfirmEmailFormItem"
import AuthentificationForm from "./Generics/AuthentificationForm"

type RegisterFormInputs = {
    email: string
    password: string
    confirmPassword: string
}

export default function CreateAccount() {
    const [loading, setLoading] = useState<boolean>(false)
    const [form] = Form.useForm<RegisterFormInputs>()
    const userRepository = useUserService()
    const navigate = useNavigate()
    const onSubmit = async (e: RegisterFormInputs) => {
        setLoading(true)
        await userRepository
            .register({
                email: e.email,
                password: e.password,
                ConfirmPassword: e.confirmPassword,
            })
        setLoading(false)
    }
    return (
        <AuthentificationForm
            form={form}
            onFinish={onSubmit}>
            <EmailFormItem />
            <PasswordFormItem />
            <ConfirmPasswordFormItem />
            <SubmitButton loading={loading} text="Create Account" />
            <Link onClick={() => navigate("/login")}>Already registered ?</Link>
        </AuthentificationForm>

    )
}