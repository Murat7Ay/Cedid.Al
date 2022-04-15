const ENV = {
  dev: {
    apiUrl: 'http://localhost:44358',
    oAuthConfig: {
      issuer: 'http://localhost:44358',
      clientId: 'AkilliLojistik_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access AkilliLojistik',
    },
    localization: {
      defaultResourceName: 'AkilliLojistik',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44358',
    oAuthConfig: {
      issuer: 'http://localhost:44358',
      clientId: 'AkilliLojistik_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access AkilliLojistik',
    },
    localization: {
      defaultResourceName: 'AkilliLojistik',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
