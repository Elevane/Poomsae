import { LoadingOutlined } from "@ant-design/icons"
import { Button, Form } from "antd"
import React from "react"

export interface SubmitButtonProps {
  loading: boolean
  text: string
  style?: React.CSSProperties
  children?: React.ReactNode
  disabled?: boolean
}

const SubmitButton: React.FC<SubmitButtonProps> = ({ loading, text, children, style, disabled = false }) => {
  return (<Form.Item >
    <Button
      disabled={loading || disabled}
      style={{
        ...style, width: "300px", height: "40px", borderRadius: 0, fontSize: "16px", boxShadow: "box-shadow: 0 6px 0 0 rgb(183, 79, 55)"
      }}
      type="primary"
      htmlType="submit"
    >
      {loading && <LoadingOutlined />}{text}
    </Button>
    {children}
  </Form.Item>
  )
}
export default SubmitButton