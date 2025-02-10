
import { useState } from "react"
import { Form, Input } from "antd"
import { useNavigate } from "react-router-dom"
import Link from "antd/es/typography/Link"
import useUserService from "../../../Hooks/Services/UseUserService"
import SubmitButton from "../../Molecules/SubmitButton"

type LoginFormInputs = {
    email: string
    password: string
    confirmPassword: string
}
const LoginForm: React.FC = () => {
    const [form] = Form.useForm<LoginFormInputs>()
    const [loading, setLoading] = useState<boolean>(false)
    const userRepository = useUserService()
    const navigate = useNavigate()
    const onFinish = async (e: LoginFormInputs) => {
        setLoading(true)
        await userRepository.login({ email: e.email, password: e.password })
        setLoading(false)
    }

    return (

        <Form
            form={form}
            layout="horizontal"
            onFinish={onFinish}>
            <Form.Item
                name="email"
                rules={[{ required: true, message: "Enter an email" }]}
            >
                <Input placeholder="Email" style={{ width: "300px", height: "40px", borderRadius: 0 }} />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{ required: true, message: "Type you password" }]}
            >
                <Input.Password autoComplete="password" placeholder="password" style={{ width: "300px", height: "40px", borderRadius: 0 }} />
            </Form.Item>
            <SubmitButton loading={loading} text="Login" />
            <Link onClick={() => navigate("/create_account")}>Not a member ?</Link>
        </Form>

    )
}

export default LoginForm