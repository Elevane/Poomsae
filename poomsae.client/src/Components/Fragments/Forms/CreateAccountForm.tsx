
import { Form, Input } from "antd"
import Link from "antd/es/typography/Link"
import { useState } from "react"
import useUserService from "../../../Hooks/Services/UseUserService"
import { useNavigate } from "react-router"
import SubmitButton from "../../Molecules/SubmitButton"

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
    <Form
      form={form}
      layout="horizontal"
      onFinish={onSubmit}>
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
        <Input.Password style={{ width: "300px", height: "40px", borderRadius: 0 }} placeholder="password" />
      </Form.Item>
      <Form.Item
        name="confirmPassword"

        rules={[
          {
            required: true,
          },
          ({ getFieldValue }) => ({
            validator(_, value) {
              if (!value || getFieldValue('password') === value) {
                return Promise.resolve();
              }
              return Promise.reject(new Error('Passwords do no match'));
            },
          }),
        ]}
      >
        <Input.Password placeholder="Confirm yout password" style={{ width: "300px", height: "40px", borderRadius: 0 }} />
      </Form.Item>
      <SubmitButton loading={loading} text="Create Account" />
      <Link onClick={() => navigate("/login")}>Already registered ?</Link>
    </Form>


  )
}