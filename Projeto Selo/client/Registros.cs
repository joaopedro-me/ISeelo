using Microsoft.Win32;

public class RegistrarInformacoes
{

    private const string chavePath = "Software\\Iseelo\\informações";

    public void CriarRegistros()
    {
        RegistryKey chaveBase = Registry.CurrentUser;
        RegistryKey chaveRegistro = chaveBase.OpenSubKey(chavePath, true);

        if (chaveRegistro == null)
        {
            chaveRegistro = chaveBase.CreateSubKey(chavePath);
            chaveRegistro.SetValue("IP", "127.0.0.1");
            chaveRegistro.SetValue("LocalExecucao", "Sem informação");
            chaveRegistro.Close();
        }
        else
        {
            chaveRegistro.Close();
        }
    }
    public void SalvarIP(string ip)
    {
        RegistryKey chaveRegistro = Registry.CurrentUser.OpenSubKey("Software\\Iseelo\\informações", true);

        if (chaveRegistro != null)
        {
            chaveRegistro.SetValue("IP", ip);
        }

        chaveRegistro.Close();
    }

    public void SalvarExecucao(string caminho)
    {
        RegistryKey chaveRegistro = Registry.CurrentUser.OpenSubKey("Software\\Iseelo\\informações", true);

        if (chaveRegistro != null)
        {
            chaveRegistro.SetValue("LocalExecucao", caminho);
        }
        chaveRegistro.Close();
    }



}

