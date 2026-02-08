import NextAuth from "next-auth"
import { authConfig } from "./auth.config"
import createMiddleware from 'next-intl/middleware';

const intlMiddleware = createMiddleware({
  locales: ['en', 'ps'],
  defaultLocale: 'en'
});

const { auth } = NextAuth(authConfig)

export default auth((req) => {
  return intlMiddleware(req);
})

export const config = {
  // Match all pathnames except for
  // - … if they start with `/api`, `/_next` or `/_vercel`
  // - … the ones containing a dot (e.g. `favicon.ico`)
  matcher: ['/((?!api|_next|_vercel|.*\\..*).*)']
};
