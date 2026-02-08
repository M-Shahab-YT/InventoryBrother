import type { NextAuthConfig } from "next-auth"
import Credentials from "next-auth/providers/credentials"

export const authConfig = {
  providers: [
    Credentials({
      async authorize(credentials) {
        if (credentials.username === 'admin' && credentials.password === 'admin') {
          return { id: '1', name: 'Admin', email: 'admin@example.com' }
        }
        return null
      },
    }),
  ],
  pages: {
    signIn: '/login',
  },
  callbacks: {
    authorized({ auth, request: { nextUrl } }) {
      const isLoggedIn = !!auth?.user
      const isPublicRoute = nextUrl.pathname === '/' || nextUrl.pathname.endsWith('/login')
      
      if (isPublicRoute && isLoggedIn) {
        return Response.redirect(new URL('/dashboard', nextUrl))
      }

      if (!isPublicRoute) {
        if (isLoggedIn) return true
        return false 
      }
      return true
    },
  },
} satisfies NextAuthConfig
