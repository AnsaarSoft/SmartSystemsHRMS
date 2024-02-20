namespace SSUI.Authorization
{
    public class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string prmJwtString)
        {
            List<Claim> claims = new List<Claim>();
            try
            {
                //var payload = prmJwtString.Split('.')[1];
                //var jsonBytes = ParseBase64String(payload);
                //Dictionary<string, object> keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                //ParseRolesFromJwt(claims, keyValuePairs);

                //claims.AddRange(keyValuePairs.Select(a => new Claim(a.Key, a.Value.ToString())));
                Claim SuperClaim = new Claim("Super", "Super");
                claims.Add(SuperClaim);
                return claims;
            }
            catch (Exception ex)
            {
                //LogsUI.GenerateLogs(ex.Message);
            }
            return claims;
        }

        private static byte[] ParseBase64String(string prmValue)
        {
            try
            {
                switch (prmValue.Length % 4)
                {
                    case 2:
                        prmValue += "==";
                        break;
                    case 3:
                        prmValue += "=";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //LogsUI.GenerateLogs(ex.Message);
            }
            return Convert.FromBase64String(prmValue);
        }

        private static void ParseRolesFromJwt(List<Claim> claims, Dictionary<string, object> keyValuePairs)
        {
            try
            {
                keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
                if (roles is not null)
                {
                    var parseRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');
                    if (parseRoles.Length > 1)
                    {
                        foreach (var parseRole in parseRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, parseRole.Trim('"')));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parseRoles[0]));
                    }
                    keyValuePairs.Remove(ClaimTypes.Role);
                }
            }
            catch (Exception ex)
            {
                //LogsUI.GenerateLogs(ex.Message);
            }
        }
    }
}
